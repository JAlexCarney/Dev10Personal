using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolRestSharp
{
    class RoomService
    {
        private RestClient _client;

        public RoomService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public void GetRoom()
        {
            Console.Write("Enter room id: ");
            int id = int.Parse(Console.ReadLine());

            var request = new RestRequest($"api/rooms/{id}", Method.GET);
            var response = _client.Get<Room>(request);

            if (response.IsSuccessful)
            {
                Room r = response.Data;
                Console.WriteLine($"{r.roomID} : {r.buildingID}");
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public void AddRoom()
        {
            Room r = new Room();
            Console.Write("Add room number: ");
            r.roomNumber = int.Parse(Console.ReadLine());
            Console.Write("Add room description: ");
            r.description = Console.ReadLine();
            Console.Write("Add building Id: ");
            r.buildingID = int.Parse(Console.ReadLine());

            var request = new RestRequest($"api/rooms", Method.POST);
            request.AddJsonBody(r);
            var response = _client.Post(request);

            if (response.IsSuccessful)
            {
                var location = response.Headers.First(h => h.Name == "Location").Value;
                Console.WriteLine($"Find created room at: {location}");
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public void EditRoom()
        {
            Room r = new Room();
            Console.Write("Add room number: ");
            r.roomNumber = int.Parse(Console.ReadLine());
            Console.Write("Add room description: ");
            r.description = Console.ReadLine();
            Console.Write("Add building Id: ");
            r.buildingID = int.Parse(Console.ReadLine());

            var request = new RestRequest($"api/rooms", Method.PUT);
            request.AddJsonBody(r);
            var response = _client.Put(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Room updated successfully!");
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public void DeleteRoom()
        {
            Console.Write("Enter room id: ");
            int id = int.Parse(Console.ReadLine());

            var request = new RestRequest($"api/rooms/{id}", Method.DELETE);
            var response = _client.Delete(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Room deleted!");
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }
    }
}
