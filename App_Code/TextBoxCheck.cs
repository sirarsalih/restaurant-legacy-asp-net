using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for TextBoxCheck
/// </summary>
public class TextBoxCheck
{
	public TextBoxCheck()
	{

	}

    public bool textBoxChecks(TextBox fromTimeTextBox, TextBox fromTimeTextBox2, Label emptyTimeLabel, TextBox toTimeTextBox, TextBox toTimeTextBox2)
    {
        if (fromTimeTextBox.Text == "")
        {
            emptyTimeLabel.Visible = true;
            return true;
        }

        else if(fromTimeTextBox.Text != "" && fromTimeTextBox2.Text != "" && toTimeTextBox.Text != "" && toTimeTextBox2.Text != "")
        {
            emptyTimeLabel.Visible = false;
            return false;
        }

        if (fromTimeTextBox2.Text == "")
        {
            emptyTimeLabel.Visible = true;
            return true;
        }

        else if (fromTimeTextBox.Text != "" && fromTimeTextBox2.Text != "" && toTimeTextBox.Text != "" && toTimeTextBox2.Text != "")
        {
            emptyTimeLabel.Visible = false;
            return false;
        }

        if (toTimeTextBox.Text == "")
        {
            emptyTimeLabel.Visible = true;
            return true;
        }

        else if (fromTimeTextBox.Text != "" && fromTimeTextBox2.Text != "" && toTimeTextBox.Text != "" && toTimeTextBox2.Text != "")
        {
            emptyTimeLabel.Visible = false;
            return false;
        }

        if (toTimeTextBox2.Text == "")
        {
            emptyTimeLabel.Visible = true;
            return true;
        }

        else if (fromTimeTextBox.Text != "" && fromTimeTextBox2.Text != "" && toTimeTextBox.Text != "" && toTimeTextBox2.Text != "")
        {
            emptyTimeLabel.Visible = false;
            return false;
        }

        else
        {
            return false;        
        }
    
    }

}
