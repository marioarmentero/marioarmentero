using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aicogestnew
{
    public class LoginShellFlyoutMenuItem
    {
        public LoginShellFlyoutMenuItem()
        {
            TargetType = typeof(LoginShellFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}