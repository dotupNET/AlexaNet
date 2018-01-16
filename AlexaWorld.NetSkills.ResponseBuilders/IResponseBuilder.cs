using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaWorld.NetSkills.ResponseBuilders
{
	public interface IResponseBuilder<T>
	{
		T Build();
	}
}
