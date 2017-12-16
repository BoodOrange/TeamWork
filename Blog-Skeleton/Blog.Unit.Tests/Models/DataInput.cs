namespace Blog.Unit.Tests.Models
{
    public class DataInput
    {
        public User TestUser { get; set; } = new User(
            fullname: "Full Name", 
            email: "TestEmail_01@test.com", 
            password: "Testpassword_1", 
            newPassword: "Testpassword_1"
        );

        public User TestUser2 { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_02@test.com",
            password: "Testpassword_2",
            newPassword: "Testpassword_2"
        );

        public User TestUser3 { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_03@test.com",
            password: "Testpassword_3",
            newPassword: "Testpassword_3"
        );

        public User ChangeUser { get; set; } = new User(
            fullname: "Full Name", 
            email: "TestEmail_01@test.com", 
            password: "Testpassword_1", 
            newPassword: "Testpassword_2", 
            confirmPassword: "Testpassword_2"
        );

        public User WrongUser { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_01@test.com",
            password: "Testpassword_1",
            newPassword: "Testpassword_2",
            confirmPassword: "Testpassword_3"
        );

        public User WeakUser { get; set; } = new User(
            fullname: "Full Name",
            email: "TestEmail_01@test.com",
            password: "Testpassword_1",
            newPassword: "1",
            confirmPassword: "1"
        );

        public Article TestArticle { get; set; } = new Article(
            title: "Lorem ipsum dolor sit",
            content: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi ac pretium velit. Morbi laoreet mauris ac est congue, quis iaculis."
        );
    }
}