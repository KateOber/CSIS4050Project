using EFControllerUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheMobileShopCodeFirstFromDB;
using TheMobileShopValidation;

namespace TheMobleShopFormsApp
{
    /// <summary>
    /// Form to add or update inventory items. Reeds data into listBox
    /// Whn user selects an item from the listbox, the data is copied over
    /// to fields which can be modified for update or used to add.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public partial class TheMobileShopInventory : Form
    {
        public TheMobileShopInventory()
        {
            InitializeComponent();

            //register the event handlers
            this.Load += TheMobileShopInventory_Load;
            buttonAddItem.Click += ButtonAddItem_Click;
            buttonUpdateItem.Click += ButtonUpdateItem_Click;

            //register the event handler for selected item
            listBoxInventory.SelectedIndexChanged += (s, e) => GetSelectedItem();

            this.Text = "The Mobile Shop Inventory";

        }

        private void GetSelectedItem()
        {
            // if not selected
            if (!(listBoxInventory.SelectedItem is Inventory item))
                return;
            // display 
            textBoxName.Text = item.Name;
            textBoxBrand.Text = item.Brand;
            textBoxDescription.WordWrap = true;
            textBoxDescription.Text = item.Description;
            textBoxCost.Text = item.Cost.ToString();
            textBoxPrice.Text = item.Price.ToString();
            numericUpDownQuantity.Value = item.Quantity;

            // itarate through the listbox of cat
            // set selected to the one that has the same Id
            for (int i = 0; i < listBoxCategory.Items.Count; i++)
            {
                //null check!
                if (item.CategoryId == (listBoxCategory.Items[i] as Category)?.CategoryId)
                {
                    listBoxCategory.SetSelected(i, true);
                }
            }

        }

        private void ButtonUpdateItem_Click(object sender, EventArgs e)
        {
            if (!(listBoxInventory.SelectedItem is Inventory inventory))
            {
                MessageBox.Show("Select an Item to update");
                return;
            }
            //get input values and set
            inventory.Name = textBoxName.Text;
            inventory.Brand = textBoxBrand.Text;
            inventory.Cost = double.Parse(textBoxCost.Text);
            inventory.Price = double.Parse(textBoxPrice.Text);
            inventory.Description = textBoxDescription.Text;
            inventory.Quantity = Int32.Parse(numericUpDownQuantity.Value.ToString());
            if (listBoxCategory.SelectedIndex != -1)
            {
                Category category = listBoxCategory.SelectedItem as Category;
                inventory.Category = category;
            }
            if (!inventory.DataIsValid())
            {
                MessageBox.Show("Inventory data is missing.");
                return;
            }
            if(Controller<TheMobileShopEntities, Inventory>.UpdateEntity(inventory) == false)
            {
                MessageBox.Show("Something went wrong with DB!");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            Category category = null;
            //get selected Category
            if (listBoxCategory.SelectedIndex != -1)
            {
                category = listBoxCategory.SelectedItem as Category;
            }
            
            //Create new Inventory object
            Inventory newInventory = new Inventory()
            {
                Name = textBoxName.Text,
                Brand = textBoxBrand.Text,
                Category = category,
                Quantity = Int32.Parse(numericUpDownQuantity.Value.ToString()),
                Price = double.Parse(textBoxPrice.Text),
                Cost = double.Parse(textBoxCost.Text),
                Description = textBoxDescription.Text
        };
            if (!newInventory.DataIsValid())
            {
                    MessageBox.Show("Some data is missing.");
                    return;
            }
            //Try to add new Item to the Inventory
            if(Controller<TheMobileShopEntities, Inventory>.AddEntity(newInventory) == null)
            {
                MessageBox.Show("Con not Add this Item");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();

        }
       
        private void TheMobileShopInventory_Load(object sender, EventArgs e)
        {
            //Get Entites from Inventory table and seed the listBox with items
            listBoxInventory.DataSource =
               Controller<TheMobileShopEntities, Inventory>.SetBindingList();
            //set no selected items at start
            listBoxInventory.SelectedIndex = -1;

            //empty all input fields
            textBoxName.ResetText();
            textBoxBrand.ResetText();
            textBoxCost.ResetText();
            textBoxPrice.ResetText();
            textBoxDescription.ResetText();
            numericUpDownQuantity.ResetText();

            //clear the category items and add new items to listbox
            listBoxCategory.Items.Clear();
            listBoxCategory.DataSource =
              Controller<TheMobileShopEntities, Category>.SetBindingList();
            //set no selected items at start
            listBoxCategory.SelectedIndex = -1;


        }
        
    }
}
