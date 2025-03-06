// See https://aka.ms/new-console-template for more information
using Microsoft.Playwright;

Console.WriteLine("Hello, World!");

// Launch Playwright browser
var playwright = await Playwright.CreateAsync();
var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });  // Set 'Headless' to false to see the browser

// Open a new page (browser tab)
var page = await browser.NewPageAsync();

// Navigate to the 'The Internet' login page
await page.GotoAsync("https://the-internet.herokuapp.com/login");

// Fill out the login form using the ID selectors
await page.FillAsync("input[id='username']", "tomsmith");  // Replace with your username
await page.FillAsync("input[id='password']", "SuperSecretPassword!");  // Replace with your password

// Click the "Login" button to submit the form
await page.ClickAsync("button[type='submit']");   // This triggers the login action

// Wait for the page to load after login
await page.WaitForSelectorAsync("div.flash.success");  // Example of success message

// Take a screenshot after successful login
await page.ScreenshotAsync(new PageScreenshotOptions { Path = "login_success.png" });

// Close the browser
await browser.CloseAsync();

Console.WriteLine("Automation completed successfully!");
