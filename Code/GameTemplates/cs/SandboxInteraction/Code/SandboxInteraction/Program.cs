// Copyright 2001-2016 Crytek GmbH / Crytek Group. All rights reserved.

using System;
using CryEngine.Resources;
using CryEngine.Components;
using CryEngine.FlowSystem;
using System.Reflection;

namespace CryEngine.SandboxInteraction
{
	/// <summary>
	/// AddIn Entry point will be re-instantiated in runtime, whenever the assembly is updated (e.g. Re-compiled).
	/// </summary>
	public class Program : ICryEngineAddIn
	{
		public static event EventHandler<FlowNode, PropertyInfo> OnSignal;

		private Application _app;

		public void Initialize(InterDomainHandler handler)
		{
			if (!Env.IsSandbox)
				Env.Console.ExecuteString ("map SandboxInteraction");
			_app = Application.Instantiate<SandboxInteractionApp>();
		}

		public void OnFlowNodeSignal(FlowNode node, PropertyInfo signal)
		{
			if (OnSignal != null)
				OnSignal (node, signal);
		}

		public void Shutdown()
		{
			_app.Shutdown (false);
		}
	}
}
