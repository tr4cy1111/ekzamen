using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace MobileExam.DB
{
    internal class Storage
    {
        SQLiteConnection database;
        public Storage(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Note>();
            database.CreateTable<Type>();
            database.CreateTable<User>();
        }

        public IEnumerable<Note> GetNotes()
        {
            return database.Table<Note>().ToList();
        }

        public IEnumerable<Type> GetTypes()
        {
            return database.Table<Type>().ToList();
        }

        public Note GetNote(int id)
        {
            return database.Get<Note>(id);
        }

        public int SaveNote(Note note)
        {
            if (note.Id != 0)
            {
                database.Update(note);
                return note.Id;
            }
            else
            {
                return database.Insert(note);
            }
        }

        public int SaveType(DB.Type type)
        {
            if (type.Id != 0)
            {
                database.Update(type);
                return type.Id;
            }
            else
            {
                return database.Insert(type);
            }
        }

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                database.Update(user);
                return user.Id;
            }
            else
            {
                return database.Insert(user);
            }
        }

        public User GetUser( string password)
        {
            return GetUsers().Where(user => user.Password == password).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public int DeleteProject(int idProject)
        {
            return database.Delete<Note>(idProject);
        }
    }
}
