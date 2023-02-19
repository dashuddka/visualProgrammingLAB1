using Avalonia.Controls;
using Avalonia.VisualTree;

namespace TestUnitApp
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I");
            var text = mainWindow.GetVisualDescendants().OfType<TextBox>().First(c => c.Name == "Show");

            button.Command.Execute(button.CommandParameter);

            await Task.Delay(50);
            var Numb = text.Text;

            Assert.True(Numb.Equals("I")); 
        }
        [Fact]
        public async void Test2()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var button = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "C");
            var text = mainWindow.GetVisualDescendants().OfType<TextBox>().First(c => c.Name == "Show");

            button.Command.Execute(button.CommandParameter);

            await Task.Delay(50);
            var Numb = text.Text;

            Assert.True(Numb.Equals("C"));
        }
    }
}