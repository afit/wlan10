using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Bertware.Wlan10.Controller;
using Net.Bertware.Wlan10.Model;

namespace Net.Bertware.Wlan10.Tests
{
    [TestClass]
    public class NetshellTests
    {
        private const string enGB_profiles = @"
Profiles on interface Wi-Fi:

Group policy profiles (read only)
---------------------------------
    <None>

User profiles
-------------
    All User Profile     : Network #1
    All User Profile     : Another network
    All User Profile     : Here's a network
    All User Profile     : Wifi3

";
        private const string frFR_profiles = @"
Profils sur l'interface Wi-Fi :

Profils de stratégies de groupe(lecture seule)
-----------------------------------------------
    x: Wifi1
    x: Wifi2

** Profils utilisateurs**
-------------
    <Aucun>

";
        private const string itIT_profiles = @"
Profili sull'interfaccia Wi-Fi:

Profili di Criteri di gruppo (sola lettura)
 ---------------------------------
<Nessuno>

Profili utente
-------------
Tutti i profili utente    : dlink
Tutti i profili utente    : NETGEAR_EXT
Tutti i profili utente    : NETGEAR99-5G
Tutti i profili utente    : NETGEAR99_EXT 2
Tutti i profili utente    : NETGEAR99
Tutti i profili utente    : DIRECT-EF-HP ENVY 4520 series
Tutti i profili utente    : Wireless-N
Tutti i profili utente    : NETGEAR99_EXT
Profilo utente corrente: Bagno.b
Tutti i profili utente    : Infostrada-2.4GHz-09312B
Tutti i profili utente    : nexAPV
Profilo utente corrente: blue_fac

";

        [TestMethod]
        public void TestGetNetworkNames()
        {
            Assert.AreEqual( 4, Netshell.GetNetworkNames( enGB_profiles ).Count );
            Assert.AreEqual( 2, Netshell.GetNetworkNames( frFR_profiles ).Count );
            Assert.AreEqual( 12, Netshell.GetNetworkNames( itIT_profiles ).Count );
        }
    }
}
