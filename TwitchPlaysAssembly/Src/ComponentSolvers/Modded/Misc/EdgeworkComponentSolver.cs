﻿using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class EdgeworkComponentSolver : ComponentSolver
{
	public EdgeworkComponentSolver(TwitchModule module) :
		base(module)
	{
		_component = module.BombComponent.GetComponent(ComponentType);
		_buttons = (KMSelectable[]) ButtonsField.GetValue(_component);
		ModInfo = ComponentSolverFactory.GetModuleInfo(GetModuleType(), "Press an answer using !{0} press left. Answers can be referred to numbered from left to right. They can also be referred to by their position.");
	}

	private static int? ButtonToIndex(string button)
	{
		return button switch
		{
			"left" or "l" or "1" => 0,
			"middle" or "m" or "center" or "centre" or "c" or "2" => 1,
			"right" or "r" or "3" => 2,
			_ => null,
		};
	}

	protected internal override IEnumerator RespondToCommandInternal(string inputCommand)
	{
		string[] commands = inputCommand.ToLowerInvariant().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		if (commands.Length != 2 || !commands[0].EqualsAny("press", "submit", "click", "answer")) yield break;
		if (!(bool) CanPressButtonsField.GetValue(_component))
		{
			yield return null;
			yield return "sendtochaterror You can't interact with the module right now.";
			yield break;
		}

		int? buttonIndex = ButtonToIndex(commands[1]);
		if (buttonIndex == null) yield break;

		yield return null;

		_buttons[(int) buttonIndex].OnInteract();
		yield return new WaitForSeconds(0.1f);
	}

	private static readonly Type ComponentType = ReflectionHelper.FindType("EdgeworkModule");
	private static readonly FieldInfo ButtonsField = ComponentType.GetField("Buttons", BindingFlags.Public | BindingFlags.Instance);
	private static readonly FieldInfo CanPressButtonsField = ComponentType.GetField("canPressButtons", BindingFlags.NonPublic | BindingFlags.Instance);

	private readonly KMSelectable[] _buttons;
	private readonly object _component;
}
