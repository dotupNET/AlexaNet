using AlexaWorld.SkillKit.Responses.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.NetSkills.ResponseBuilders
{
	public class CardBuilder
	{
		private Card card;

		public CardBuilder WithSimpleCard()
		{
			this.card = new SimpleCard();
			return this;
		}

		public CardBuilder WithSimpleCard(string title, string content)
		{
			this.card = new SimpleCard()
			{
				Title = title,
				Content = content
			};
			return this;
		}

		public CardBuilder WithStandardCard(string title, string text, string smallImage, string largeImage)
		{
			this.card = new StandardCard()
			{
				Title = title,
				Text = text,
				Image = new Image()
				{
					SmallImageUrl = smallImage,
					LargeImageUrl = largeImage
				}

			};
			return this;
		}

		public Card Build()
		{
			return card;
		}
	}
}
