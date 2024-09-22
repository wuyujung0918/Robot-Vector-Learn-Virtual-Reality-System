# Virtual Reality-Based Robotics Vector Learning System

**Copyright (c) 2024 - Virtual Robotics Learning System**

## Introduction

Welcome to the **Virtual Reality-Based Robotics Vector Learning System**, a project aimed at providing learners with an immersive experience in learning robotic vectors and angles through virtual reality technology. This system allows learners to engage with various challenges and interfaces where they can observe, control, and understand robotic arm movements and vector calculations in different angles and coordinate systems.

The system offers a highly interactive platform where users can learn by observation, practice by adjusting robotic arm angles, and evaluate their understanding through quizzes and tasks.

## Features

- **Robotic Arm Angle Control**: Interactive control of multiple robotic arm joints and rotation angles.
- **Vector Calculation and Display**: Real-time vector calculations based on user input.
- **Button and Slider Controls**: Intuitive user interface with buttons and sliders for easy interaction.
- **Scene Switching**: Quickly switch between different learning environments and quizzes.
- **Image Display & Hide Functionality**: Enable and disable images based on learning scenarios.

## Getting Started

The `docs` folder contains a comprehensive guide for getting started and using this system effectively.

### Project Architecture

1. **ArmBoneCtrl.cs**  
   Controls the rotation of each joint of the robotic arm. Users can set the rotation angles and observe how the arm moves accordingly. This script handles angle updates and the smooth animation of rotations.

2. **FakeArmCtrl.cs**  
   Manages the overall control of the robotic arm. It processes button events to rotate specific joints of the arm. This script works with `ArmBoneCtrl.cs` to achieve precise control of the arm's movement.

3. **UItext.cs**  
   This script provides the user interface control for adjusting the robotic arm's angles via buttons, sliders, and input fields. It allows learners to interactively modify angles and see the real-time effect on the robotic arm.

4. **GameController.cs**  
   Handles the switching between different scenes or learning stages. Learners can navigate through different learning environments and tasks using this controller.

5. **HideImage.cs**  
   Provides functionality to show and hide images, allowing users to focus on specific learning content or test scenarios.

6. **LookAtCamera.cs**  
   Ensures that objects, such as the robotic arm, are always oriented towards the camera, providing an optimal view for learners.

7. **MainCtrl.cs**  
   This is the primary system controller that initializes the robotic arm controls and listens for user input events to trigger interactions and movements.

### Basic Testing Functions

- **TEST_ASSERT_EQUAL_VECTOR(expected, actual)**  
  Compares two vectors for equality, showing an error message if they differ.

- **TEST_ASSERT_ARM_POSITION(arm, expected_position)**  
  Verifies that the robotic arm is in the expected position in the coordinate system.

- **TEST_ASSERT_ROTATION(degree, expected_degree)**  
  Confirms that the rotation angle is correct as per the given value.

### Angle and Coordinate Control

1. **ArmBoneCtrl**  
   - `RotateRight()`: Rotates the specified joint to the right.
   - `RotateLeft()`: Rotates the specified joint to the left.
   - `SetTargetDegree(degree)`: Sets the target degree for the joint rotation.

2. **UItext**  
   - `TaskOnClickLeft()`: Decreases the angle when the left button is pressed.
   - `TaskOnClickRight()`: Increases the angle when the right button is pressed.
   - `BarInputEventEnd(float num)`: Adjusts the angle based on the slider input.

### Image and Object Interaction

1. **HideImage**  
   - `HideImageObject(int index)`: Toggles the visibility of images based on button input.

2. **LookAtCamera**  
   - Ensures objects always face the camera, providing the learner with an optimal view.

### Quizzes

Learners will be tested on their understanding through interactive quizzes that include controlling vectors, verifying the robotic arm’s position, and adjusting the correct rotation angles.

---

This project offers a complete learning system that combines virtual reality and robotics to help learners grasp key concepts of robotic arm control. The system is designed to be interactive, with real-time feedback to enhance the learning experience.

For more information and detailed documentation, please refer to the project files.
