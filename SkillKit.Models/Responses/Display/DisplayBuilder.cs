using AlexaWorld.SkillKit.Responses.Cards;
using AlexaWorld.SkillKit.Responses.Display.Directives;
using System;
using System.Collections.Generic;
using System.Text;
using static AlexaWorld.SkillKit.AMAZON;
using static AlexaWorld.SkillKit.AMAZON.Display;
using static AlexaWorld.SkillKit.Responses.Display.DisplayImageSource;

namespace AlexaWorld.SkillKit.Responses.Display
{
	public class DisplayBuilder
	{
		private IDisplayTemplate template;

		public DisplayRenderTemplateDirective Build()
		{
			return new DisplayRenderTemplateDirective(template);
		}

		public DisplayBuilder FromTemplate(BodyTemplateType templateType)
		{
			this.template = new BodyTemplate(templateType);
			return this;
		}

		public DisplayBuilder FromTemplate(ListTemplateType templateType, List<IListItem> listItems)
		{
			this.template = new ListTemplate()
			{
				Type = templateType.ToString(),
				ListItems = listItems
			};
			return this;
		}

		public DisplayBuilder WithTitle(string title)
		{
			template.Title = title;
			return this;
		}

		public DisplayBuilder WithToken(string token)
		{
			template.Token = token;
			return this;
		}

		public DisplayBuilder WithImage(string description, string url, ImageSizeEnum imageSizeEnum)
		{
			template.Image = new DisplayImage()
			{
				ContentDescription = description,
				Sources = new List<DisplayImageSource>() {
					new DisplayImageSource() { Url = url, Size = imageSizeEnum }
				}
			};
			return this;
		}


		public DisplayBuilder WithBackgroundImage(string description, string url, ImageSizeEnum imageSizeEnum)
		{
			template.BackgroundImage = new DisplayImage()
			{
				ContentDescription = description,
				Sources = new List<DisplayImageSource>() {
					new DisplayImageSource() { Url = url, Size = imageSizeEnum }
				}
			};
			return this;
		}

		public DisplayBuilder HideBackButton()
		{
			template.BackButton = BodyTemplate.ButtonVisibilityEnum.HIDDEN;
			return this;
		}

		public DisplayBuilder WithPrimaryPlainText(string text)
		{
			Guard.NullRequired(template.TextContent.PrimaryText, "PrimaryText already used");
			template.TextContent.PrimaryText = text;
			return this;
		}

		//public DisplayBuilder WithPrimaryPlainText(string text, FontSizeEnum fontSize)
		//{
		//	var formated = AMAZON.FontSize.GetText(fontSize, text);
		//	template.TextContent.PrimaryText = formated;
		//	return this;
		//}

		public DisplayBuilder WithSecondaryPlainText(string text)
		{
			Guard.NullRequired(template.TextContent.SecondaryText, "SecondaryText already used");
			template.TextContent.SecondaryText = text;
			return this;
		}

		public DisplayBuilder WithTertiaryPlainText(string text)
		{
			Guard.NullRequired(template.TextContent.TertiaryText, "TertiaryText already used");
			template.TextContent.TertiaryText = text;
			return this;
		}

		public DisplayBuilder WithPrimaryRichText(string text)
		{
			Guard.NullRequired(template.TextContent.PrimaryText, "PrimaryText already used");
			template.TextContent.PrimaryText = new TextField() { Type = TextField.TextTypeEnum.RichText, Text = text };
			return this;
		}

		public DisplayBuilder WithPrimaryRichText(string text, FontSizeEnum fontSize)
		{
			Guard.NullRequired(template.TextContent.PrimaryText, "PrimaryText already used");
			var formated = FontSize.GetText(fontSize, text);
			template.TextContent.PrimaryText = new TextField() { Type = TextField.TextTypeEnum.RichText, Text = formated };
			return this;
		}


		public DisplayBuilder WithSecondaryRichText(string text)
		{
			Guard.NullRequired(template.TextContent.SecondaryText, "SecondaryText already used");
			template.TextContent.SecondaryText = new TextField() { Type = TextField.TextTypeEnum.RichText, Text = text };
			return this;
		}

		public DisplayBuilder WithSecondaryRichText(string text, FontSizeEnum fontSize)
		{
			Guard.NullRequired(template.TextContent.SecondaryText, "SecondaryText already used");
			var formated = FontSize.GetText(fontSize, text);
			template.TextContent.SecondaryText = new TextField() { Type = TextField.TextTypeEnum.RichText, Text = formated };
			return this;
		}

		public DisplayBuilder WithTertiaryRichText(string text)
		{
			Guard.NullRequired(template.TextContent.TertiaryText, "TertiaryText already used");
			template.TextContent.TertiaryText = new TextField() { Type = TextField.TextTypeEnum.RichText, Text = text };
			return this;
		}

		public DisplayBuilder WithTertiaryRichText(string text, FontSizeEnum fontSize)
		{
			Guard.NullRequired(template.TextContent.TertiaryText, "TertiaryText already used");
			var formated = FontSize.GetText(fontSize, text);
			template.TextContent.TertiaryText = new TextField() { Type = TextField.TextTypeEnum.RichText, Text = formated };
			return this;
		}
	}
}
