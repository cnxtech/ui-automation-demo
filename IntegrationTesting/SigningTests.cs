using NUnit.Framework;

namespace IntegrationTesting
{
    [TestFixture]
    public class SigningTests:TestMethodsContainer
    {
        [Test]
        [Category("Signing")]
        [Property("Driver", "CHROME")]
        [Property("Resolution_X", "1920")]
        [Property("Resolution_Y", "1080")]
        public void SingleDocumentSign()
        {
            NavigateToSigningPage();
            InitiateSigning();
            SigningConsole_Continue();
            PerformSigning();
            SigningConsole_Finish();
        }


    }

}
