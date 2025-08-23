using Microsoft.Playwright;
using SwagLabsTests.Hooks;

namespace SwagLabsTests.PageObjects;

[Binding]
public class ProductsPage : BasePage
{
    // Existing Backpack selectors
    private ILocator BackpackAddToCartButtonSelector => Page.Result.Locator("//button[@id='add-to-cart-sauce-labs-backpack']");
    private ILocator BackpackRemoveFromCartButtonSelector => Page.Result.Locator("//button[@id='remove-sauce-labs-backpack']");
    private ILocator BackpackItemNameSelector => Page.Result.Locator("//div[@class='inventory_item_name ' and text()= 'Sauce Labs Backpack']");
    private ILocator BackpackDetailsNameSelector => Page.Result.Locator("//div[@class='inventory_details_name large_size' and text()= 'Sauce Labs Backpack']");
    
    // Bike Light selectors
    private ILocator BikeLightAddToCartButtonSelector => Page.Result.Locator("//button[@id='add-to-cart-sauce-labs-bike-light']");
    private ILocator BikeLightRemoveFromCartButtonSelector => Page.Result.Locator("//button[@id='remove-sauce-labs-bike-light']");
    
    // T-Shirt selectors
    private ILocator TShirtAddToCartButtonSelector => Page.Result.Locator("//button[@id='add-to-cart-sauce-labs-bolt-t-shirt']");
    private ILocator TShirtRemoveFromCartButtonSelector => Page.Result.Locator("//button[@id='remove-sauce-labs-bolt-t-shirt']");
    private ILocator TShirtItemNameSelector => Page.Result.Locator("//div[@class='inventory_item_name ' and text()= 'Sauce Labs Bolt T-Shirt']");
    private ILocator TShirtDetailsNameSelector => Page.Result.Locator("//div[@class='inventory_details_name large_size' and text()= 'Sauce Labs Bolt T-Shirt']");
    private ILocator TShirtPriceSelector => Page.Result.Locator("//div[contains(@class, 'inventory_item') and .//div[text()='Sauce Labs Bolt T-Shirt']]//div[@class='inventory_item_price']");
    
    // Common selectors
    private ILocator ShoppingCartBadgeSelector => Page.Result.Locator("//span[@class='shopping_cart_badge']");
    private ILocator ShoppingCartButtonSelector => Page.Result.Locator("//a[@class='shopping_cart_link']");
    private ILocator BackToProductsButtonSelector => Page.Result.Locator("//button[@id='back-to-products']");
    private ILocator ProductsPageTitleSelector => Page.Result.Locator("//span[@class='title' and text()= 'Products']");
    
    public ProductsPage(TestExecutionHooks hooks) : base(hooks) { }
    
    // Backpack methods
    public async Task ClickBackPackAddToCartButton()
    {
        await BackpackAddToCartButtonSelector.ClickAsync();
    }
    
    public async Task ClickBackPackRemoveFromCartButton()
    {
        await BackpackRemoveFromCartButtonSelector.ClickAsync();
    }
    
    public async Task ClickBackPackItemName()
    {
        await BackpackItemNameSelector.ClickAsync();
    }
    
    public async Task AssertBackPackWasAddedToCart()
    {
        await Assertions.Expect(BackpackRemoveFromCartButtonSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertBackPackDetailsNameIsVisible()
    {
        await Assertions.Expect(BackpackDetailsNameSelector).ToBeVisibleAsync();
    }
    
    // Bike Light methods
    public async Task ClickBikeLightAddToCartButton()
    {
        await BikeLightAddToCartButtonSelector.ClickAsync();
    }
    
    public async Task AssertBikeLightWasAddedToCart()
    {
        await Assertions.Expect(BikeLightRemoveFromCartButtonSelector).ToBeVisibleAsync();
    }
    
    // T-Shirt methods
    public async Task ClickTShirtAddToCartButton()
    {
        await TShirtAddToCartButtonSelector.ClickAsync();
    }
    
    public async Task ClickTShirtItemName()
    {
        await TShirtItemNameSelector.ClickAsync();
    }
    
    public async Task AssertTShirtWasAddedToCart()
    {
        await Assertions.Expect(TShirtRemoveFromCartButtonSelector).ToBeVisibleAsync();
    }
    
    public async Task AssertTShirtDetailsNameIsVisible()
    {
        await Assertions.Expect(TShirtDetailsNameSelector).ToBeVisibleAsync();
    }
    
    public async Task<string> GetTShirtPrice()
    {
        return await TShirtPriceSelector.TextContentAsync() ?? "";
    }
    
    public async Task ClickBackToProductsButton()
    {
        await BackToProductsButtonSelector.ClickAsync();
    }
    
    public async Task AssertProductsPageIsVisible()
    {
        await Assertions.Expect(ProductsPageTitleSelector).ToBeVisibleAsync();
    }
    
    // Common methods
    public async Task ClickShoppingCartButton()
    {
        await ShoppingCartButtonSelector.ClickAsync();
    }
    
    public async Task AssertThereIsOneItemAddedToCart()
    {
        await Assertions.Expect(ShoppingCartBadgeSelector).ToHaveTextAsync("1");
    }
    
    public async Task AssertThereAreTwoItemsAddedToCart()
    {
        await Assertions.Expect(ShoppingCartBadgeSelector).ToHaveTextAsync("2");
    }
    
    public async Task AssertBackToProductsButtonIsVisible()
    {
        await Assertions.Expect(BackToProductsButtonSelector).ToBeVisibleAsync();
    }
}