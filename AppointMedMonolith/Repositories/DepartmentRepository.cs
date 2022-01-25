using AppointMed.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppointMed.API.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private const string databaseName = "appointmed";
    private const string collectionName = "departments";
    private readonly IMongoCollection<Department> departmentCollection;
    private readonly FilterDefinitionBuilder<Department> filterBuilder = Builders<Department>.Filter;
    public DepartmentRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
        departmentCollection = database.GetCollection<Department>(collectionName);
    }
    public async Task CreateDepartmentAsync(Department department)
    {
        await departmentCollection.InsertOneAsync(department);
    }

    public async Task DeleteDepartmentAsync(Guid id)
    {
        var filter = filterBuilder.Eq(department => department.Id, id);
        await departmentCollection.DeleteOneAsync(filter);
    }

    public async Task<Department> GetDepartmentAsync(Guid id)
    {
        var filter = filterBuilder.Eq(department => department.Id, id);
        return await departmentCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Department>> GetDepartmentsAsync()
    {
        return await departmentCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        var filter = filterBuilder.Eq(existingClinic => existingClinic.Id, department.Id);
        await departmentCollection.ReplaceOneAsync(filter, department);
    }
}
