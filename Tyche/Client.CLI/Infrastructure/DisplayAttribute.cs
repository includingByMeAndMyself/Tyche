using System;


namespace Client.CLI.Infrastructure
{
    public class DisplayAttribute : Attribute
    {
        public string Name { get; set; }

        public DisplayAttribute()
        {

        }
    }
}
