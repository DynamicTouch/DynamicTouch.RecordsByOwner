namespace DynamicTouch.RecordsByOwner
{
    using System;

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}