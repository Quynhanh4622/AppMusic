using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusic.Entities
{
    public enum Gender
    {
        female = 0,
        male = 1,
        other = 2
    }
    public class Account
    {
        private string introduction1;

        public int id { get; set; }
        public int role { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public string introduction { get => introduction1==null?"": introduction1; set => introduction1 = value; }
        public string created_at { get; set; }
        public int status { get; set; }

        public override string ToString()
        {
            return $"First Name: {firstName}, Last Name: {lastName}, Password: {password}, Address: {address}, Phone: {phone}, Avatar: {avatar}, Gender: {gender}, Email: {email}, Birthday: {birthday}";
        }

        public string GetGenderAsString()
        {
            if (gender == 1)
            {
                return "Male";
            }
            else if (gender == 0)
            {
                return "Female";
            }
            else if (gender == 2)
            {
                return "Other";
            }
            return "Unknown";
        }
        public string GetStaticAsString()
        {
            if (status == 1)
            {
                return "Active";
            }
            else if (gender == 0)
            {
                return "Deactive";
            }
            return "Unknown";
        }
    }
}
