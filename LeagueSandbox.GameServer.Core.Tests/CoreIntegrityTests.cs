using System;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueSandbox.GameServer.Lib.Tests
{
	[TestClass]
	public class IntegrityTests : WhereContainerIsAvailable
	{
		[TestMethod]
		public void AllRequestDefinitionsMustBeInsideCoreProject()
		{
			var assemblies = GetAllApplicationAssemblies();
			var requestDefinitions = assemblies.SelectMany(x => x.GetTypes()).Where(x => typeof(IRequestDefinition).IsAssignableFrom(x));
			var requestDefinitionsOutsideCore = requestDefinitions.Where(x => x.Assembly != CoreAssemblyDefiningType.Assembly).ToList();
			if (requestDefinitionsOutsideCore.Any())
				Assert.Fail($"All request definitions must be inside Core project.{Environment.NewLine}{string.Join(Environment.NewLine, requestDefinitionsOutsideCore)}");
		}

		[TestMethod]
		public void AllRequestDefinitionsMustHaveSingleServerAction()
		{
			var errors = new StringBuilder();
			var assemblies = GetAllApplicationAssemblies();
			var allTypes = assemblies.SelectMany(x => x.GetTypes()).Where(x => !x.IsAbstract).ToList();
			var requests = allTypes.Where(x => typeof(IRequestDefinition).IsAssignableFrom(x));
			var serverActions = allTypes.Where(x => typeof(IServerAction).IsAssignableFrom(x)).ToList();
			foreach (var request in requests)
			{
				var requestServerActions = serverActions.Where(x => x.GenericBaseClassHasArgumentOfTypeInHierarchy(typeof(ServerActionBase<>), request)).ToList();
				if (requestServerActions.Count > 1)
					errors.AppendLine($"More than one ServerAction found for request {request}: {Environment.NewLine}{string.Join(Environment.NewLine, requestServerActions)}");
				if (requestServerActions.Count == 0)
					errors.AppendLine($"No ServerAction found for request {request}");
			}
			
			if(!string.IsNullOrWhiteSpace(errors.ToString()))
				Assert.Fail(errors.ToString());
		}
	}
}
