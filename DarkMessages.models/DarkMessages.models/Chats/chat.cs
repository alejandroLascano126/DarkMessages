using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Chats
{
    public class chat
    {
        public int chatId { get; set; }
        public int typeChatId { get; set; }
        public int entityId { get; set; }
        public string name { get; set; }
        public int userIdRelated { get; set; }
        public string? lastMessage { get; set; }
        public string? friendUsername { get; set; }
        public DateTime dateCreated { get; set; }
        public string? email { get; set; }
        public DateTime dateUpdated { get; set; }
        public string? description { get; set; }
        public byte[]? profilePicture { get; set; }
    }
}
