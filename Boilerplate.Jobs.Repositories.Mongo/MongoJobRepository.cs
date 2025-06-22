using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Boilerplate.Jobs.Repositories.Mongo
{
    public class MongoJobRepository : IJobRepository
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName = "jobs";

        public MongoJobRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public MongoJobRepository(IMongoDatabase database, string collectionName)
            : this(database)
        {
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
        }

        public IEnumerable<Job> GetAllByStatus(int offset, int pageSize, params JobStatus[] statuses) =>
            Collection
                .Find(Builders<Job>.Filter.In(x => x.Status, statuses))
                .SortByDescending(x => x.StartedAt)
                .Skip(offset)
                .Limit(pageSize)
                .ToList();

        public async Task<IEnumerable<Job>> GetAllByStatusAsync(int offset, int pageSize, params JobStatus[] statuses)
        {
            return await Collection
                .Find(Builders<Job>.Filter.In(x => x.Status, statuses))
                .SortByDescending(x => x.StartedAt)
                .Skip(offset)
                .Limit(pageSize)
                .ToListAsync();
        }

        public Job GetById(Guid id) =>
            Collection.Find(x => x.Id == id).FirstOrDefault();

        public Task<Job> GetByIdAsync(Guid id) =>
            Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public void Save(Job job)
        {
            Collection.UpdateOne(
                x => x.Id == job.Id,
                Builders<Job>.Update
                    .Set(x => x.Name, job.Name)
                    .Set(x => x.Type, job.Type)
                    .Set(x => x.UserId, job.UserId)
                    .Set(x => x.UserEmail, job.UserEmail)
                    .Set(x => x.Data, job.Data)
                    .Set(x => x.Status, job.Status)
                    .Set(x => x.Error, job.Error)
                    .Set(x => x.StartedAt, job.StartedAt)
                    .Set(x => x.CompletedAt, job.CompletedAt),
                new UpdateOptions
                {
                    IsUpsert = true
                });
        }

        public Task SaveAsync(Job job)
        {
            return Collection.UpdateOneAsync(
                x => x.Id == job.Id,
                Builders<Job>.Update
                    .Set(x => x.Name, job.Name)
                    .Set(x => x.Type, job.Type)
                    .Set(x => x.UserId, job.UserId)
                    .Set(x => x.UserEmail, job.UserEmail)
                    .Set(x => x.Data, job.Data)
                    .Set(x => x.Status, job.Status)
                    .Set(x => x.Error, job.Error)
                    .Set(x => x.StartedAt, job.StartedAt)
                    .Set(x => x.CompletedAt, job.CompletedAt),
                new UpdateOptions
                {
                    IsUpsert = true
                });
        }

        private IMongoCollection<Job> Collection => _database.GetCollection<Job>(_collectionName);
    }
}