using System.Windows.Forms;

namespace WebScraper
{
    public class ListBoxEx : ListBox
    {
        public void InitSelection()
        {
            if (Items.Count > 0)
                SelectedIndex = 0;
        }

        public void AppendItem(object item)
        {
            SelectedIndex = Items.Add(item);
        }

        public void ReplaceItem(object item)
        {
            if (SelectedIndex >= 0)
                Items[SelectedIndex] = item;
            else
                AppendItem(item);
        }

        public void DeleteItem()
        {
            int index = SelectedIndex;
            if (index >= 0)
            {
                Items.RemoveAt(index);
                if (Items.Count > 0)
                {
                    if (index >= Items.Count)
                        index = (Items.Count - 1);
                    SelectedIndex = index;
                }
            }
        }

        #region Move up/down

        public bool CanMoveUp => SelectedIndex > 0;
        public bool CanMoveDown => SelectedIndex < (Items.Count - 1);

        /// <summary>
        /// Moves the selected item up one position.
        /// </summary>
        public bool MoveUp()
        {
            int index = SelectedIndex;
            if (index > 0)
            {
                object temp = Items[index];
                Items[index] = Items[index - 1];
                Items[index - 1] = temp;
                SelectedIndex = index - 1;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Moves the selected item down one position.
        /// </summary>
        public bool MoveDown()
        {
            int index = SelectedIndex;
            if (index < (Items.Count - 1))
            {
                object temp = Items[index];
                Items[index] = Items[index + 1];
                Items[index + 1] = temp;
                SelectedIndex = index + 1;
                return true;
            }
            return false;
        }

        #endregion

    }
}
