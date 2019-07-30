namespace NaturaDomain.Model
{
    public class Product
    {
        public int id{get;set;}
        public string name{get;set;}
        public virtual Category Category{get;set;}
        public int amount{get;set;}
        public int size{get;set;}
        public int unity{get;set;}
        public int Categoryid{get;set;}
        public string image{get;set;}
    }
}