﻿using AccessManager.Models.Database;
using AccessManager.Models.Requests.AccessHistory;
using Newtonsoft.Json;

namespace AccessManager.Models.DataModels
{
    public class DepartmentInfo
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public static explicit operator DepartmentInfo(DepartmentDbModel db) => new DepartmentInfo
        {
            Id = db.Id,
            Name = db.Name
        };

        public static explicit operator DepartmentInfo(AddDepartmentRequest db) => new DepartmentInfo
        {
            Id = Guid.NewGuid(),
            Name = db.Name
        };

        public static implicit operator DepartmentDbModel(DepartmentInfo db) => new DepartmentDbModel
        {
            Id = db.Id,
            Name = db.Name
        };
    }
}
