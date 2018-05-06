using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace bank
{
    [XmlRoot("cl")]
    public class OldBankClient
    {
        [XmlElement("fn")]
        public String firstName {get; set;}

        [XmlElement("ln")]
        public String lastName {get; set;}

        [XmlElement("mn")]
        public String middleName {get; set;}

        [XmlElement("p")]
        public String phone {get; set;}

        [XmlElement("e")]
        public String email {get; set;}

        [XmlElement("bd")]
        public int birthdateDay {get; set;}

        [XmlElement("bm")]
        public int birthdateMonth {get; set;}

        [XmlElement("by")]
        public int birthdateYear  {get; set;}

        [XmlElement("hl1")]
        public String homeAddress {get; set;}

        [XmlElement("hc")]
        public String homeAddressCity {get; set;}

        [XmlElement("hs")]
        public String homeAddressState {get; set;}

        [XmlElement("hz")]
        public String homeAddressZip {get; set;}

        [XmlElement("wl1")]
        public String workAddress {get; set;}

        [XmlElement("wc")]
        public String workAddressCity {get; set;}

        [XmlElement("ws")]
        public String workAddressState {get; set;}

        [XmlElement("wz")]
        public String workAddressZip {get; set;}
    }

    public class Address
    {
        [XmlElement("zip")]
        public String zip {get; set;}

        [XmlElement("state")]
        public String state {get; set;}

        [XmlElement("city")]
        public String city {get; set;}

        [XmlElement("address")]
        public String address {get; set;}

        public Address(String zip, String state, String city, String address)
        {
            this.zip = zip;
            this.state = state;
            this.city = city;
            this.address = address;
        }

        public Address () {}
    }

    public class PassportData
    {
        [XmlElement("surname")]
        public String lastName {get; set;}

        [XmlElement("name")]
        public String firstName {get; set;}

        [XmlElement("middleName")]
        public String middleName {get; set;}

        [XmlElement("birthDate")]
        public DateTime birthDate {get; set;}

        public PassportData(String lastName, String firstName, String middleName, DateTime birthDate)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.birthDate = birthDate;
        }

        public PassportData () {}
    }

    public class Contacts
    {
        [XmlElement("phone")]
        public String phone {get; set;}

        [XmlElement("email")]
        public String email {get; set;}

        public Contacts (String phone, String email)
        {
            this.phone = phone;
            this.email = email;
        }

        public Contacts () {}
    }

    [XmlRoot("bankClient")]
    public class NewBankClient
    {
        [XmlElement("passportData")]
        public PassportData passportData {get; set;}

        [XmlElement("contacts")]
        public Contacts contacts {get; set;}

        [XmlElement("homeAddress")]
        public Address homeAddress {get; set;}

        [XmlElement("workAddress")]
        public Address workAddress {get; set;}

        public NewBankClient (OldBankClient client)
        {
            this.passportData = new PassportData(
                client.lastName,
                client.firstName,
                client.middleName,
                new DateTime(
                    client.birthdateYear,
                    client.birthdateMonth,
                    client.birthdateDay
                )
            );

            this.contacts = new Contacts(
                client.email,
                client.phone
            );

            this.homeAddress = new Address(
                client.homeAddressZip,
                client.homeAddressState,
                client.homeAddressCity,
                client.homeAddress
            );

            this.workAddress = new Address(
                client.workAddressZip,
                client.workAddressState,
                client.workAddressCity,
                client.workAddress
            );
        }

        public NewBankClient () {}
    }
}