using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.API
{
    public class APIAuth
    {
        protected string Key { get; set; }
    }

    // I'm creating a new class which is inherited from APIAuth to hide my API Keys.
    /* 
        If you want to use API, you either need to: 
            1. Set Key property value to your API key.
            2. Create a new class, which is inherited from APIAuth class:
                public class APIAuthLocal : APIAuth
                {
                    public APIAuthLocal()
                    {
                        this.Key = "Your-key";
                    }
                }
    */
}
