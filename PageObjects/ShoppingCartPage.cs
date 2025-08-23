using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class ShoppingCartPage : BasePage
{
    private ILocator CheckoutButtonSelector => Page.Result.Locator("//button[@id='checkout']");
    private ILocator ShoppingCartPageTitleSelector => Page.Result.Locator("//span[@class='title' and text()= 'Your Cart']");
    
    public ShoppingCartPage(TestExecutionHooks hooks) : base(hooks) { }
    
    public async Task ClickCheckoutButton()
    {
        await CheckoutButtonSelector.ClickAsync();
    }
    
    public async Task AssertShoppingCartPageIsVisible()
    {
        await Assertions.Expect(ShoppingCartPageTitleSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertItemIsInCart(string itemName)
    {
        var itemSelector = Page.Result.Locator($"//div[@class='inventory_item_name' and text()='{itemName}']");
        await Assertions.Expect(itemSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertItemPriceIsCorrect(string itemName, string expectedPrice)
    {
        var itemPriceSelector = Page.Result.Locator($"//div[@class='inventory_item_name' and text()='{itemName}']/../..//div[@class='inventory_item_price']");
        await Assertions.Expect(itemPriceSelector).ToHaveTextAsync(expectedPrice);
    }
}