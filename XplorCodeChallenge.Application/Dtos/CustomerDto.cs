using System;
namespace XplorCodeChallenge.Application.Dtos
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Salutation { get; set; }
        public string Initials { get; set; }
        public string Firstname { get; set; }
        public string FirstnameAscii { get; set; }
        public string Gender { get; set; }
        public string FirstnameCountryRank { get; set; }
        public string FirstnameCountryFrequency { get; set; }
        public string Lastname { get; set; }
        public string LastnameAscii { get; set; }
        public string LastnameCountryRank { get; set; }
        public string LastnameCountryFrequency { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeAlpha { get; set; }
        public string CountryName { get; set; }
        public string PrimaryLanguageCode { get; set; }
        public string PrimaryLanguage { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
}
