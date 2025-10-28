Physics Simulations in C#

This repository presents a collection of interactive physics simulations implemented in C# (Windows Forms). Each simulation visualizes a fundamental physical phenomenon — combining mathematical modeling, numerical methods, and computer graphics.

https://github.com/FatimaIjazOfficial/Computational-Physics_Simulations/blob/master/CPS/Form1.cs file is main class

All projects have been designed for educational and demonstrative purposes, helping learners visualize equations of motion, understand physical laws, and explore numerical techniques like Euler and Euler-Cromer integration.

🔬 Project List
1. Radioactive Decay Simulation

Simulates exponential decay of unstable nuclei using a simple differential model:

N(t + Δt) = N(t) − τ · N(t) · Δt
Visualizes how the number of nuclei decreases with time.

2. Uniform Velocity Simulation

Demonstrates motion with constant velocity.

x(t) = x₀ + v · t
Plots displacement versus time, showing linear dependence.

3. Free-Falling Object (Height & Displacement) Simulations

Models gravitational motion with uniform acceleration:

h(t + Δt) = h(t) − ½ g t²
v(t + Δt) = v(t) − g · Δt
Displays height and displacement variations over time.

4. Parachute Motion Simulation

Explores air resistance using velocity-dependent drag:

v(t + Δt) = v(t) + a·Δt − b·v(t)·Δt
Illustrates terminal velocity formation under drag effects.

5. Coupled Systems Simulation

Demonstrates oscillatory behavior of two coupled pendulums or masses interacting through a spring. Shows energy transfer and phase relationship.

6. Growth of Population Simulation

Implements logistic population growth:

N(t + Δt) = N(t) + (a·N(t) − b·N(t)²)·Δt
Displays saturation effects as the population approaches carrying capacity.

7. Bicycle Motion Simulation

Models linear motion considering resistive forces and propulsion, visualizing time vs velocity.

8. Cannon Shell Motion Simulation

Simulates projectile motion with drag.

Incorporates both horizontal and vertical components of velocity and acceleration.

9. Batted Ball Simulation

Models the parabolic motion of a baseball after being hit, considering air resistance and initial launch angle.

10. Billiard Ball on a Rectangular Table Simulation

Visualizes a ball’s elastic collisions with the table boundaries, maintaining energy and changing direction upon impact.

11. Solar System Using Newtonian Mechanics

Models gravitational attraction between celestial bodies using Newton’s Law of Gravitation:

F = G·(m₁·m₂) / r²
Shows planetary orbits and relative motion under mutual gravitational influence.

12. Lorentz Model Simulation

Illustrates the motion of a charged particle in electromagnetic fields using Lorentz force law:

F = q(E + v × B)

13. Simple Pendulum Simulation

Includes multiple methods for solving pendulum motion:

Ideal Case (Euler & Euler-Cromer)

Damping and Driving Forces

Nonlinear Oscillations
Mathematical form:

ωₙ₊₁ = ωₙ − (g/l)·θₙ·Δt
θₙ₊₁ = θₙ + ωₙ₊₁·Δt

Each simulation produces two graphs — θ vs t and ω vs t — to visualize angular displacement and velocity.

⚙️ Numerical Techniques Used

Euler Method

Euler-Cromer Method

Logistic Growth Model

Differential Equation Integration

Numerical Stability & Bounded Angle Correction

🧮 Technologies

Language: C#

Framework: .NET (Windows Forms)

Graphics: GDI+ (System.Drawing)

Environment: Visual Studio

🧠 Educational Purpose

These simulations bridge mathematical equations and visual representation, enabling a deeper conceptual understanding of:

Mechanics and Kinematics

Gravitational Motion

Damping and Driving Oscillations

Exponential and Logistic Models

🔗 Website Reference

You can explore detailed write-ups and visual demonstrations for each project here:
https://sites.google.com/view/fatima-ijaz/c-projects

📜 Author
Fatima Ijaz
BS in Computational Physics — Univerity of the Punjab
Focused on Computational Physics and Scientific Simulations.
Certified: 100 Days of Code – The Complete Python Pro Bootcamp by Dr. Angela Yu
