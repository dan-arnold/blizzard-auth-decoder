blizzard-auth-decoder
=====================

Decodes Blizzard Mobile Authenticator settings file into Serial and Secret Key, for use with various TOTP apps.

----
###Usage:
1.  Configure Blizzard Mobile Authenticator on your Android device.
2.  Grab /data/data/com.blizzard.bma/shared_prefs/com.blizzard.bma.AUTH_STORE.xml using Root Explorer, adb pull, etc.
3.  Take the map/string[@name='com.blizzard.bma.AUTH_STORE.HASH] value and paste into the "hash" variable of my code.
4.  Compile and run, it will calculate the Serial and Secret Key from the given hash.
5.  Enter Serial and Secret Key into TOTP app of your choice

----
###Testing done:
*  Tested with my Battle.net account and https://play.google.com/store/apps/details?id=uk.co.bitethebullet.android.token.
*  Generates the same code as the Blizzard Mobile Authenticator app.

----
###Known issues:
*  No UI or console input, requires code change to use different key (yes this is terrible, I know)

----
###References:
*  http://forum.xda-developers.com/showpost.php?p=7303107&postcount=94
*  https://code.google.com/p/winauth/
  * _Note:_
_I reused the StringToByteArray and ByteArrayToString methods from winauth, thus I have also released my code under the same GPL license._
