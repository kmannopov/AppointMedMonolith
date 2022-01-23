using AppointMed.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppointMed.API.Repositories;

public class ClinicRepository : IClinicRepository
{
    private const string databaseName = "appointmed";
    private const string collectionName = "clinics";
    private readonly IMongoCollection<Clinic> clinicCollection;
    private readonly FilterDefinitionBuilder<Clinic> filterBuilder = Builders<Clinic>.Filter;
    public ClinicRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
        clinicCollection = database.GetCollection<Clinic>(collectionName);
    }
    public async Task CreateClinicAsync(Clinic clinic)
    {
        await clinicCollection.InsertOneAsync(clinic);
    }

    public async Task DeleteClinicAsync(Guid id)
    {
        var filter = filterBuilder.Eq(clinic => clinic.Id, id);
        await clinicCollection.DeleteOneAsync(filter);
    }

    public async Task<Clinic> GetClinicAsync(Guid id)
    {
        var filter = filterBuilder.Eq(clinic => clinic.Id, id);
        return await clinicCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Clinic>> GetClinicsAsync()
    {
        return await clinicCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateClinicAsync(Clinic clinic)
    {
        var filter = filterBuilder.Eq(existingClinic => existingClinic.Id, clinic.Id);
        await clinicCollection.ReplaceOneAsync(filter, clinic);
    }
}
