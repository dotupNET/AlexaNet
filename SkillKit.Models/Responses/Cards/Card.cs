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
	public abstract class Card
	{
		/// <summary>
		/// A string describing the type of card to render.Valid types are:
		/// 
		/// "Simple": A card that contains a title and plain text content.
		/// 
		/// "Standard": A card that contains a title, text content, and an image to display.
		/// 
		/// "LinkAccount": a card that displays a link to an authorization URL that the user can use to link their Alexa account with a user in another system. See Linking an Alexa User with a User in Your System for details.
		/// </summary>
		public string Type { get; set; }
	}
}