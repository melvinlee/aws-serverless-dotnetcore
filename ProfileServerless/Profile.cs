using System.Collections.Generic;

namespace ProfileServerless
{
    public class Profile
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Certification> Certifications { get; set; }
    }

    public class Skill
    {
        public string Category { get; set; }
        public List<string> Description { get; set; }
    }

    public class Certification
    {
        public string Authority { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Url { get; set; }
    }
}
