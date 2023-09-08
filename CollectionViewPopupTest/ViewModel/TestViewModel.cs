using CollectionViewPopupTest.Localization;

namespace CollectionViewPopupTest.ViewModel
{
    public class TestViewModel
    {
        public string Title { get; }

        public string SubTitle { get; }

        public IReadOnlyList<TestItem> Items { get; }

        public TestViewModel() 
        {
            Title = AppResources.TestPopupTitle;
            SubTitle = AppResources.TestPopupSubtitle;
            Items = new List<TestItem>()
            { 
                new TestItem() { Name = "Item1", SomeNumber = 1 },
                new TestItem() { Name = "Item2", SomeNumber = 2 },
                new TestItem() { Name = "Item3", SomeNumber = 3 },
                new TestItem() { Name = "Item4", SomeNumber = 4 },
                new TestItem() { Name = "Item5", SomeNumber = 5 },
            };
        }
    }
}
