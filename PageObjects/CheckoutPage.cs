using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class CheckoutPage : BasePage
{
    private ILocator FirstNameInputSelector => Page.Result.Locator("//input[@id='first-name']");
    private ILocator LastNameInputSelector => Page.Result.Locator("//input[@id='last-name']");
    private ILocator ZipCodeInputSelector => Page.Result.Locator("//input[@id='postal-code']");
    private ILocator ContinueCheckoutButtonSelector => Page.Result.Locator("//input[@id='continue']");
    private ILocator FinishCheckoutButtonSelector => Page.Result.Locator("//button[@id='finish']");
    private ILocator CompletedOrderMessageSelector => Page.Result.Locator("//h2[@class='complete-header' and text()= 'Thank you for your order!']");
    private ILocator CheckoutPageTitleSelector => Page.Result.Locator("//span[@class='title' and text()= 'Checkout: Your Information']");
    private ILocator CheckoutOverviewTitleSelector => Page.Result.Locator("//span[@class='title' and text()= 'Checkout: Overview']");
    
    public CheckoutPage(TestExecutionHooks hooks) : base(hooks) { }
    
    public async Task ClickContinueCheckoutButton()
    {
        await ContinueCheckoutButtonSelector.ClickAsync();
    }
    
    public async Task ClickFinishCheckoutButton()
    {
        await FinishCheckoutButtonSelector.ClickAsync();
    }
    
    public async Task FillInFirstNameInput(string firstName)
    {
        await FirstNameInputSelector.FillAsync(firstName);
    }
    
    public async Task FillInLastNameInput(string lastName)
    {
        await LastNameInputSelector.FillAsync(lastName);
    }
    
    public async Task FillInZipCodeInput(string zipCode)
    {
        await ZipCodeInputSelector.FillAsync(zipCode);
    }
    
    public async Task AssertCheckoutPageIsVisible()
    {
        await Assertions.Expect(CheckoutPageTitleSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertCheckoutOverviewIsVisible()
    {
        await Assertions.Expect(CheckoutOverviewTitleSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertOrderCompletionIsVisible()
    {
        await Assertions.Expect(CompletedOrderMessageSelector).ToBeVisibleAsync();
    }
    
    // Legacy method name for backward compatibility
    public async Task AssertCompletedOrderMessageIsVisible()
    {
        await AssertOrderCompletionIsVisible();
    }
}