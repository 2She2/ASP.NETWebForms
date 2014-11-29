using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Todo;

namespace _02_TodoList
{
    public partial class TodoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListViewTodos_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            ToDosDbEntities db = new ToDosDbEntities();
            this.LabelErrorMessages.Text = string.Empty;
            this.LabelSuccessMessages.Text = string.Empty;

            try
            {
                TextBox titleTextBox = (e.Item.FindControl("TitleTextBox") as TextBox);
                this.ValidateTitleTextBox(titleTextBox);

                TextBox bodyTextBox = (e.Item.FindControl("BodyTextBox") as TextBox);
                this.ValidateBodyTextBox(titleTextBox);

                TextBox categoryTextBox = (e.Item.FindControl("CategoryTextBox") as TextBox);
                this.ValidateCategoryTextBox(titleTextBox);
                string newCategory = Server.HtmlEncode(categoryTextBox.Text);

                Category enteredCategory = db.Categories.FirstOrDefault(cat => cat.Name.ToLower() == newCategory.ToLower());
                if (enteredCategory == null)
                {
                    enteredCategory = new Category()
                    {
                        Name = newCategory,
                    };

                    db.Categories.Add(enteredCategory);
                    db.SaveChanges();
                }

                string categoryId = enteredCategory.Id.ToString();
                string currDate = DateTime.Now.ToString();
                this.EntityDataSourceTodos.InsertParameters.Add("CategoryId", TypeCode.Int32, categoryId);
                this.EntityDataSourceTodos.InsertParameters.Add("LastUpdated", TypeCode.DateTime, currDate);

                this.LabelSuccessMessages.Text = "Todo successfuly added!";
                this.ListViewTodos.DataBind();
            }
            catch (Exception ex)
            {
                this.LabelErrorMessages.Text = ex.Message;
                e.Cancel = true;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        protected void ListViewTodos_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            ToDosDbEntities db = new ToDosDbEntities();
            this.LabelErrorMessages.Text = string.Empty;
            this.LabelSuccessMessages.Text = string.Empty;

            try
            {
                ListViewItem item = this.ListViewTodos.Items[e.ItemIndex];

                TextBox titleTextBox = (item.FindControl("TitleEditTextBox") as TextBox);
                this.ValidateTitleTextBox(titleTextBox);

                TextBox bodyTextBox = (item.FindControl("BodyEditTextBox") as TextBox);
                this.ValidateBodyTextBox(bodyTextBox);

                TextBox categoryTextBox = (item.FindControl("CategoryEditTextBox") as TextBox);
                this.ValidateCategoryTextBox(categoryTextBox);
                string newCategory = Server.HtmlEncode(categoryTextBox.Text);

                int index = this.ListViewTodos.EditIndex;
                DataKey dataKey = this.ListViewTodos.DataKeys[index];

                string todoId = dataKey.Value.ToString();
                var currTodo = db.ToDos.FirstOrDefault(todo => todo.Id.ToString() == todoId);
                if (currTodo == null)
                {
                    throw new ArgumentException("Current Todo was not found!");
                }

                Category enteredCategory = db.Categories.FirstOrDefault(cat => cat.Name.ToLower() == newCategory.ToLower());
                if (enteredCategory == null)
                {
                    enteredCategory = new Category()
                    {
                        Name = newCategory,
                    };

                    db.Categories.Add(enteredCategory);
                    db.SaveChanges();
                }

                if (currTodo.CategoryId != enteredCategory.Id)
                {
                    currTodo.CategoryId = enteredCategory.Id;
                    this.LabelErrorMessages.Text = "Successfuly edited!";
                }

                currTodo.LastUpdated = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                this.LabelErrorMessages.Text = ex.Message;
                e.Cancel = true;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        private void ValidateTitleTextBox(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentException("Can't find Title TextBox!");
            }

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                throw new ArgumentException("Enter a title. Can't be empty!");
            }

            if (textBox.Text.Length > 50)
            {
                throw new ArgumentException("Title length must be 50 symbols or less!");
            }
        }

        private void ValidateBodyTextBox(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentException("Can't find Body TextBox!");
            }

            if (textBox.Text == null)
            {
                throw new ArgumentException("Body TextBox text is null!");
            }
        }

        private void ValidateCategoryTextBox(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentException("Can't find Category TextBox!");
            }

            if (textBox.Text == null)
            {
                throw new ArgumentException("Category TextBox text is null!");
            }
        }

    }
}