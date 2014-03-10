using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Domain;
using MongoDB.Bson;

namespace RAM.Core.Domain.User
{
    public interface IUser : IBaseUser
    {
        bool IsActive { get; set; }
        string Password { get; set; }
        string PasswordQuestion { get; set; }
        string PasswordAnswer { get; set; }
        DateTime LastLoginDate { get; set; }
        int AccessLevel { get; set; }
        ObjectId Id { get; set; }

        ObjectId ChangedBy { get; set; }
        ObjectId EnteredBy { get; set; }
        DateTime LastUpdated { get; set; }
        DateTime DateCreated { get; set; }
    }
}
