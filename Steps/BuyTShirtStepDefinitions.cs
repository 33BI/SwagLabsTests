using TechTalk.SpecFlow;
using System.Threading.Tasks;
using SwagLabsTests.PageObjects;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.Steps
{
    [Binding]
    public class BuyTShirtStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly ProductsPage _productsPage;
        private readonly ShoppingCartPage _shoppingCartPage;
        private readonly CheckoutPage _checkoutPage;
        private string _tshirtPrice = string.Empty;

        public BuyTShirtStepDefinitions(LoginPage loginPage, ProductsPage productsPage, 
                                       ShoppingCartPage shoppingCartPage, CheckoutPage checkoutPage)
        {
            _loginPage = loginPage;
            _productsPage = productsPage;
            _shoppingCartPage = shoppingCartPage;
            _checkoutPage = checkoutPage;
        }

        [Given(@"I am logged in to Swag Labs as a standard user")]
        public async Task GivenIAmLoggedInToSwagLabsAsAStandardUser()
        {
            await _loginPage.GoToSwagLabs();
            await _loginPage.EnterUserName(TestExecutionHooks.Configs.Username);
            await _loginPage.EnterPassword(TestExecutionHooks.Configs.Password);
            await _loginPage.ClickLogin();
            await _loginPage.AssertLandingPage();
        }

        [When(@"I view the details of the Sauce Labs Bolt T-Shirt")]
        public async Task WhenIViewTheDetailsOfTheSauceLabsBoltTShirt()
        {
            await _productsPage.ClickTShirtItemName();
            await _productsPage.AssertTShirtDetailsNameIsVisible();
            await _productsPage.AssertBackToProductsButtonIsVisible();
            await _productsPage.ClickBackToProductsButton();
            await _productsPage.AssertProductsPageIsVisible();
        }

        [When(@"I add the Sauce Labs Bolt T-Shirt to the cart for \$15\.99")]
        public async Task WhenIAddTheSauceLabsBoltTShirtToTheCartFor()
        {
            _tshirtPrice = await _productsPage.GetTShirtPrice();
            await _productsPage.ClickTShirtAddToCartButton();
            await _productsPage.AssertTShirtWasAddedToCart();
            await _productsPage.AssertThereIsOneItemAddedToCart();
        }

        [When(@"I view the shopping cart")]
        public async Task WhenIViewTheShoppingCart()
        {
            await _productsPage.ClickShoppingCartButton();
            await _shoppingCartPage.AssertShoppingCartPageIsVisible();
        }

        [Then(@"I should see the Sauce Labs Bolt T-Shirt in my cart with the correct price")]
        public async Task ThenIShouldSeeTheSauceLabsBoltTShirtInMyCartWithTheCorrectPrice()
        {
            await _shoppingCartPage.AssertItemIsInCart("Sauce Labs Bolt T-Shirt");
            await _shoppingCartPage.AssertItemPriceIsCorrect("Sauce Labs Bolt T-Shirt", _tshirtPrice);
        }

        [When(@"I proceed to checkout")]
        public async Task WhenIProceedToCheckout()
        {
            await _shoppingCartPage.ClickCheckoutButton();
            await _checkoutPage.AssertCheckoutPageIsVisible();
        }
    }
}