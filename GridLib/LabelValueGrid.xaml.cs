using System.Windows;
using System.Windows.Controls;

namespace GridLib {

    public class LabelValueGrid : Grid {
        public LabelValueGrid() : base() {
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Auto);
            ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved) {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            int curRow = -1;
            int curCol = 0;
            RowDefinitions.Clear();

            if (Children != null) {
                foreach (UIElement curChild in Children) {
                    if (curCol == 0) {
                        RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                        curRow += 1;
                    }

                    Grid.SetRow(curChild, curRow);
                    Grid.SetColumn(curChild, curCol);

                    curCol += 1;
                    if (curCol == 2)
                        curCol = 0;
                }
            }
        }
    }

}
