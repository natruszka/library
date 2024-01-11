using library.Entities;

namespace library.Services.Interfaces;

public interface IPublisherService
{
    ICollection<Publisher> GetAllPublishers();
    Publisher GetPublisherById(int id);
    Task AddNewPublisher(String name);
}