// File:    RoomDao.cs
// Created: Wednesday, May 27, 2020 2:19:10 PM
// Purpose: Definition of Class RoomDao

using System;
using System.Collections.Generic;
using System.Linq;
using Klinika.Database.Csv.Converter.Clinic;
using Klinika.Database.Csv.Stream;
using Model.Manager;

namespace Dao.Clinic.CSVImpl
{
    public class RoomDao : IRoomDao
    {
        private ICSVStream<Room> _stream;

        public RoomDao(string path, string delimiter)
        {
            _stream = new CSVStream<Room>(path, new RoomCSVConverter(delimiter));
        }

        public RoomDao(ICSVStream<Room> stream)
        {
            _stream = stream;
        }
        public int Count() => _stream.ReadAll().ToList().Count;

        public void Delete(Room room) => DeleteById(room.Id);

        public void DeleteAll() => SaveAll(new List<Room>());

        public void DeleteById(string id)
        {
            List<Room> rooms = _stream.ReadAll().ToList();
            Room toRemove = rooms.SingleOrDefault(r => r.Id.CompareTo(id) == 0);
            if (toRemove != null)
            {
                rooms.Remove(toRemove);
                _stream.SaveAll(rooms);
            }
            else
            {
                Console.WriteLine("Room not found!");
            }
        }

        public bool ExistsById(string id) => FindById(id) != null ? true : false;

        public IEnumerable<Room> FindAll() => _stream.ReadAll().ToList();

        public Room FindById(string id)
            => FindAll().SingleOrDefault(r => r.Id.CompareTo(id) == 0);

        public Room Save(Room newRoom)
        {
            List<Room> rooms = _stream.ReadAll().ToList();
            Room room = rooms.SingleOrDefault(r => r.Id.CompareTo(newRoom.Id) == 0);
            if (room != null)
            {
                rooms[rooms.FindIndex(r => r.Id.CompareTo(room.Id) == 0)] = newRoom;
                _stream.SaveAll(rooms);
            }
            else
            {
                _stream.AppendToFile(newRoom);
            }
            return newRoom;
        }

        public void SaveAll(IEnumerable<Room> rooms)
        {
            foreach(Room r in rooms)
            {
                Save(r);
            }
        }
    }
}