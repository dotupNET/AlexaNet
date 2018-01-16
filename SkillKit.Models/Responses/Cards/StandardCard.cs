// Copyright 2017 Peter Ullrich, dotup IT solutions. All rights reserved.

namespace AlexaWorld.SkillKit.Responses.Cards
{
	/// <summary>
	/// This object can only be included when sending a response to a LaunchRequest or IntentRequest.
	/// </summary>
	/// <remarks>
	/// https://developer.amazon.com/de/docs/custom-skills/request-and-response-json-reference.html#card-object
	/// 
	/// https://developer.amazon.com/docs/custom-skills/include-a-card-in-your-skills-response.html
	/// </remarks>
	public class StandardCard : Card
	{
		public StandardCard()
		{
			this.Type = AMAZON.Cards.StandardCard;
		}
		/// <summary>
		/// A string containing the title of the card. (not applicable for cards of type LinkAccount).
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// A string containing the text content for a Standard card (not applicable for cards of type Simple or LinkAccount)
		/// </summary>
		/// <remarks>Tip: To include line breaks, use either \r\n or \n within the content of the card.</remarks>
		public string Text { get; set; }

		/// <summary>
		/// An image object that specifies the URLs for the image to display on a Standard card. Only applicable for Standard cards.
		/// 
		///	You can provide two URLs, for use on different sized screens.
		///		-smallImageUrl
		///		-largeImageUrl

		/// </summary>
		public Image Image { get; set; }

	}
}