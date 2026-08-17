# TurtleBot3 Burger Simulation

A Unity-based simulation of the **TurtleBot3 Burger** using the URDF importer and Unity's physics-based Articulation Body system.

## Overview

The TurtleBot3 Burger was imported into Unity using the **URDF Importer**. Its wheel movement was simulated using Unity's **Articulation Body** physics system.

Wheel articulation was implemented using **XDrive motor joints**, allowing the wheels to be driven through physics-based joint motion rather than manually changing transforms.

## Differential Drive

A C# script was used to implement differential-drive control by independently varying the speeds of the left and right wheels.

This allows the robot to:

* Move forward
* Turn
* Perform circular motion
* Change direction through differential wheel speeds

## Key Concepts

* URDF import
* Articulation Body
* XDrive joints
* Physics-based wheel motion
* Differential drive
* Wheel-ground friction
* Collision physics
* C# scripting

## Tools

* Unity
* C#
* URDF Importer
* TurtleBot3 Burger
* Ubuntu/Linux

## Purpose

The project demonstrates how a mobile robot can be imported into Unity and simulated using articulated joints, physics constraints, and differential-drive control.
