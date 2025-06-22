using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.Repositories.File
{
    public class FileJobRepository : IJobRepository
    {
        private readonly string _fileName;

        public FileJobRepository()
        {
            _fileName = "jobs.json";

            if (!System.IO.File.Exists(_fileName))
                System.IO.File.WriteAllText(_fileName, "[]");
        }

        public FileJobRepository(string fileName)
        {
            _fileName = fileName;

            if (!System.IO.File.Exists(_fileName))
                System.IO.File.WriteAllText(_fileName, "[]");
        }

        public IEnumerable<Job> GetAllByStatus(int offset, int pageSize, params JobStatus[] statuses)
        {
            var jobs = ReadFile();
            if (jobs == null)
                return Array.Empty<Job>();

            return jobs
                .Where(x => statuses.Contains(x.Status))
                .OrderByDescending(x => x.StartedAt)
                .Skip(offset)
                .Take(pageSize)
                .ToArray();
        }

        public async Task<IEnumerable<Job>> GetAllByStatusAsync(int offset, int pageSize, params JobStatus[] statuses)
        {
            var jobs = await ReadFileAsync();
            if (jobs == null)
                return Array.Empty<Job>();

            return jobs
                .Where(x => statuses.Contains(x.Status))
                .OrderByDescending(x => x.StartedAt)
                .Skip(offset)
                .Take(pageSize)
                .ToArray();
        }

        public Job GetById(Guid id)
        {
            var jobs = ReadFile();

            return jobs?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Job> GetByIdAsync(Guid id)
        {
            var jobs = await ReadFileAsync();

            return jobs?.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Job job)
        {
            var jobs = ReadFile().ToList();
            var existingJob = jobs?.FirstOrDefault(x => x.Id == job.Id);
            if (existingJob != null) 
                jobs.Remove(existingJob);
            
            jobs.Add(job);
            SaveFile(jobs);
        }

        public async Task SaveAsync(Job job)
        {
            var jobs = (await ReadFileAsync()).ToList();
            var existingJob = jobs?.FirstOrDefault(x => x.Id == job.Id);
            if (existingJob != null) 
                jobs.Remove(existingJob);

            jobs.Add(job);
            await SaveFileAsync(jobs);
        }

        private IEnumerable<Job> ReadFile()
        {
            var json = System.IO.File.ReadAllText(_fileName);
            return JsonSerializer.Deserialize<List<Job>>(json);
        }
        
        private async Task<IEnumerable<Job>> ReadFileAsync()
        {
            await using var fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            return await JsonSerializer.DeserializeAsync<List<Job>>(fileStream);
        }

        private void SaveFile(IEnumerable<Job> jobs)
        {
            var json = JsonSerializer.Serialize(jobs);
            System.IO.File.WriteAllText(_fileName, json);
        }

        private async Task SaveFileAsync(IEnumerable<Job> jobs)
        {
            await using var fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Write);
            await JsonSerializer.SerializeAsync(fileStream, jobs);
        }
    }
}