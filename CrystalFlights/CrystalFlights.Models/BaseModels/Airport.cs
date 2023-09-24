﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CrystalFlights.Models
{
    [Table("dr_Airport")]
    public class Airport : BaseModel
    {
        [CustomProperty(FieldName = "Id", FieldType = SqlDbType.BigInt)]
        public long Id { get; set; }

        [CustomProperty(FieldName = "Name", FieldType = SqlDbType.VarChar, FieldLength = 50)]
        public string? Name { get; set; }

        [CustomProperty(FieldName = "Code", FieldType = SqlDbType.VarChar, FieldLength = 3)]
        public string? Code { get; set; }

        [CustomProperty(FieldName = "CityCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? CityCode { get; set; }

        [CustomProperty(FieldName = "CityName", FieldType = SqlDbType.VarChar, FieldLength = 100)]
        public string? CityName { get; set; }

        [CustomProperty(FieldName = "StateCode", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? StateCode { get; set; }

        [CustomProperty(FieldName = "StateName", FieldType = SqlDbType.VarChar, FieldLength = 100)]
        public string? StateName { get; set; }

        [CustomProperty(FieldName = "CountryCode", FieldType = SqlDbType.VarChar, FieldLength = 2)]
        public string? CountryCode { get; set; }

        [CustomProperty(FieldName = "CountryName", FieldType = SqlDbType.VarChar, FieldLength = 100)]
        public string? CountryName { get; set; }

        [CustomProperty(FieldName = "Continent", FieldType = SqlDbType.VarChar, FieldLength = 20)]
        public string? Continent { get; set; }

        [CustomProperty(FieldName = "Latitude", FieldType = SqlDbType.Decimal)]
        public decimal Latitude { get; set; }

        [CustomProperty(FieldName = "Longtitude", FieldType = SqlDbType.Decimal)]
        public decimal Longtitude { get; set; }

        [CustomProperty(FieldName = "DisplayName", FieldType = SqlDbType.VarChar, FieldLength = 100)]
        public string? DisplayName { get; set; }

        public Airport() { }

        public Airport(string name, string code, string cityName, string cityCode, string stateName, string stateCode, string countryName, string countryCode, string continent, decimal latitude, decimal longtitude, string displayName, bool isActive, DateTime modifiedDate, long modifiedBy, DateTime createdDate, long createdBy)
        {
            this.Name = name;
            this.Code = code;
            this.CityName = cityName;
            this.CityCode = cityCode;
            this.StateName = stateName;
            this.StateCode = stateCode;
            this.CountryName = countryName;
            this.CountryCode = countryCode;
            this.Continent = continent;
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            this.DisplayName = displayName;
            this.IsActive = isActive;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
