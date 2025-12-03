using Mokeb.Domain.Model.Exceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class Address
    {
        public Address(string city, string area, string street, string alley, uint licensePlate, uint floor, uint unit, string postalCode)
        {
            CheckCity(city);
            CheckArea(area);
            CheckStreet(street);
            CheckAlley(alley);
            CheckPostalCode(postalCode);

            City = city;
            Area = area;
            Street = street;
            Alley = alley;
            LicensePlate = licensePlate;
            Floor = floor;
            Unit = unit;
            PostalCode = postalCode;
        }

        public string City { get; private set; }
        public string Area { get; private set; }
        public string Street { get; private set; }
        public string Alley { get; private set; }
        public uint LicensePlate { get; private set; }
        public uint Floor { get; private set; }
        public uint Unit { get; private set; }
        public string PostalCode { get; private set; }

        #region Behaviors
        public void ChangeCity(string city)
        {
            CheckCity(city);
            City = city;
        }
        public void ChangeArea(string area)
        {
            CheckArea(area);
            Area = area;
        }
        public void ChangeStreet(string street)
        {
            CheckStreet(street);
            Street = street;
        }
        public void ChangeAlley(string alley)
        {
            CheckAlley(alley);
            Alley = alley;
        }
        public void ChangeLicensePlate(uint plate)
        {
            LicensePlate = plate;
        }
        public void ChangeFloor(uint floor)
        {
            Floor = floor;
        }
        public void ChangeUnit(uint unit)
        {
            Unit = unit;
        }
        public void ChangePostalCode(string postalCode)
        {
            CheckPostalCode(postalCode);
            PostalCode = postalCode;
        }
        #endregion
        #region Validations
        public void CheckCity(string city)
        {
            if (string.IsNullOrEmpty(city))
                throw new CityCantBeEmptyException();
        }
        public void CheckArea(string area)
        {
            if (string.IsNullOrEmpty(area))
                throw new AreaCantBeEmptyException();
        }
        public void CheckStreet(string street)
        {
            if (string.IsNullOrEmpty(street))
                throw new StreetCantBeEmptyException();
        }
        public void CheckAlley(string alley)
        {
            if (string.IsNullOrEmpty(alley))
                throw new AlleyCantBeEmptyException();
        }
        public void CheckPostalCode(string postalCode)
        {
            if (string.IsNullOrEmpty(postalCode))
                throw new PostalCodeCantBeEmptyException();
        }
        #endregion
    }
    public class AddressBuilder
    {
        private string _city;
        private string _area;
        private string _street;
        private string _alley;
        private uint _licensePlate;
        private uint _floor;
        private uint _unit;
        private string _postalCode;

        public static AddressBuilder Empty() => new AddressBuilder();
        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }
        public AddressBuilder WithArea(string area)
        {
            _area = area;
            return this;
        }
        public AddressBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }
        public AddressBuilder WithAlley(string alley)
        {
            _alley = alley;
            return this;
        }
        public AddressBuilder WithLicensePlate(uint plate)
        {
            _licensePlate = plate;
            return this;
        }
        public AddressBuilder WithFloor(uint floor)
        {
            _floor = floor;
            return this;
        }
        public AddressBuilder WithUnit(uint unit)
        {
            _unit = unit;
            return this;
        }
        public AddressBuilder WithPostalCode(string postalCode)
        {
            _postalCode = postalCode;
            return this;
        }
        public Address Build()
        {
            return new Address(_city, _area, _street, _alley, _licensePlate, _floor, _unit, _postalCode);
        }
    }


}