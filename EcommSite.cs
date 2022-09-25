using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V102.DOM;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice
{
    using SeleniumExtras.WaitHelpers;
    internal class EcommSite
    {

        public static string Registration(string word)
        {
            string message = "";
            string email = "tare61.t@gmail.com";

            try
            {
                var eCommRegistration = Driver.Instance.FindElement(By.CssSelector("#header .nav .header_user_info > a"));
                eCommRegistration.Click();
                Thread.Sleep(1000);

                var emailAddress = Driver.Instance.FindElement(By.Id("email_create"));
                emailAddress.SendKeys(email);
                Actions builder = new Actions(Driver.Instance);
                builder.SendKeys(Keys.Enter).Perform();

                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
                IWebElement radioButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#uniform-id_gender1")));
                radioButton.Click();

                var firstName = Driver.Instance.FindElement(By.CssSelector("#customer_firstname"));
                firstName.Click();
                firstName.SendKeys("Tarik");

                var lastName = Driver.Instance.FindElement(By.CssSelector("#customer_lastname"));
                lastName.Click();
                lastName.SendKeys("Tarik");

                var passwd = Driver.Instance.FindElement(By.CssSelector("#passwd"));
                passwd.Click();
                passwd.SendKeys("uskebabo");

                var dayOfBirth = Driver.Instance.FindElement(By.Id("uniform-days"));
                dayOfBirth.Click();

                var dayOfBirth25 = Driver.Instance.FindElement(By.CssSelector("#days option:nth-child(26)"));
                dayOfBirth25.Click();

                var mounthOfBirth = Driver.Instance.FindElement(By.Id("uniform-months"));
                mounthOfBirth.Click();

                var mounthOfBirthDecember = Driver.Instance.FindElement(By.CssSelector("#months > option:nth-child(13)"));
                mounthOfBirthDecember.Click();

                var yearOfBirth = Driver.Instance.FindElement(By.CssSelector("#years"));
                yearOfBirth.Click();

                var yearOfBirth1997 = Driver.Instance.FindElement(By.CssSelector("#years option:nth-child(27)"));
                yearOfBirth1997.Click();

                var address = Driver.Instance.FindElement(By.CssSelector("#address1"));
                address.Click();
                address.SendKeys("Sedrenik");

                var city = Driver.Instance.FindElement(By.CssSelector("#city"));
                city.Click();
                city.SendKeys("Sarajevo");

                var state = Driver.Instance.FindElement(By.CssSelector("#id_state"));
                state.Click();

                var stateIllinois = Driver.Instance.FindElement(By.CssSelector("#id_state option:nth-child(15)"));
                stateIllinois.Click();

                var postalCode = Driver.Instance.FindElement(By.CssSelector("#postcode"));
                postalCode.Click();
                postalCode.SendKeys("71000");

                var country = Driver.Instance.FindElement(By.Id("uniform-id_country"));
                country.Click();

                var countryUSA = Driver.Instance.FindElement(By.CssSelector("#id_country option:nth-child(2)"));
                countryUSA.Click();

                var mobileNumber = Driver.Instance.FindElement(By.CssSelector("#phone_mobile"));
                mobileNumber.SendKeys("123456789");

                var registerButton = Driver.Instance.FindElement(By.CssSelector("#submitAccount > span"));
                registerButton.Click();
                Thread.Sleep(5000);


            }
            catch (Exception e)
            {
                message += "ERROR!!!" + e.Message;
            }
          
            return message;
        }

        public static string SearchProduct()
        {
             string searchMessage = "";

            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(20));
                IWebElement logo = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#header_logo a img")));
                logo.Click();

                var popularFirstProduct = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#homefeatured li.ajax_block_product.col-xs-12.col-sm-4.col-md-3.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line")));
                Actions actions = new Actions(Driver.Instance);
                actions.MoveToElement(popularFirstProduct);

                var addToCartButton = Driver.Instance.FindElement(By.CssSelector("#homefeatured .ajax_block_product.col-xs-12.col-sm-4.col-md-3.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line .right-block .button-container .button.ajax_add_to_cart_button.btn.btn-default > span"));
                actions.MoveToElement(addToCartButton);
                actions.Click().Build().Perform();

                IWebElement continueShopping = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#layer_cart .clearfix .layer_cart_cart.col-xs-12.col-md-6 .button-container > span > span")));
                continueShopping.Click();
          
                IWebElement popularSecondProduct = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#homefeatured > li:nth-child(2)")));
                actions.MoveToElement(popularSecondProduct);
                
                var secondProductMoreButton = Driver.Instance.FindElement(By.CssSelector("#homefeatured > li:nth-child(2) > div > div.right-block > div.button-container > a.button.lnk_view.btn.btn-default"));
                actions.MoveToElement(secondProductMoreButton);
                actions.Click().Build().Perform();

                IWebElement productSize = Driver.Instance.FindElement(By.CssSelector("#group_1"));
                productSize.Click();

                var productSizeM = Driver.Instance.FindElement(By.CssSelector("#group_1 > option:nth-child(2)"));
                productSizeM.Click();

                var productColorWhite = Driver.Instance.FindElement(By.Id("color_8"));
                productColorWhite.Click();

                var addToWishList = Driver.Instance.FindElement(By.Id("wishlist_button"));
                addToWishList.Click();

                var closeWindowAddedToWishList = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#product .fancybox-overlay.fancybox-overlay-fixed  a")));
                closeWindowAddedToWishList.Click();

                var shoppingCartBlokTop = Driver.Instance.FindElement(By.CssSelector("#header :nth-child(3) :nth-child(3) > div > a"));
                actions.MoveToElement(shoppingCartBlokTop).Perform();

                var checkoutButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#button_order_cart > span")));
                checkoutButton.Click();

                IWebElement proceedToCheckout = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#center_column .cart_navigation.clearfix .button.btn.btn-default.standard-checkout.button-medium")));
                proceedToCheckout.Click();

                var proceedToCheckout2 = Driver.Instance.FindElement(By.CssSelector("#center_column > form > p > button"));
                proceedToCheckout2.Click();

                IWebElement termsOfServiceCheckBox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#uniform-cgv > span")));
                termsOfServiceCheckBox.Click();

                var proceedToCheckout3 = Driver.Instance.FindElement(By.CssSelector("#form > p > button"));
                proceedToCheckout3.Click();

                IWebElement payByBank = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("bankwire")));
                payByBank.Click();

                var confirmMyOrderButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#cart_navigation > button")));
                confirmMyOrderButton.Click();

                Functions.TakeScreenShot();


            }

            catch (Exception e)
            {
                searchMessage += "ERROR!!!" + e.Message;
            }

            return searchMessage;
        }
    }
}