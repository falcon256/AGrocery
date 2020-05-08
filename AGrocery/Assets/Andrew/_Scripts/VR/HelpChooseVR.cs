﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;

public class HelpChooseVR : MonoBehaviour
{
  Vector3 startPos;

  public Animator playerAnims;

  public GameObject player;

  public GameObject employee;

  public GameObject askForHelpMenuCanvas;

  public GameObject mainScreenCanvas;

  public GameObject eventSystem;

  public GameObject beveragesButton;

  public Transform[] movePoints;
 

  public int walkSpeed = 5;

  public bool noHelpChosen = false;

  public bool moveToBeverages = false;

  public bool moveToBeverages2 = false;

  public bool moveToBoxDinners = false;

  public bool moveToBread = false;

  public bool moveToCannedFood = false;

  public bool moveToCereal = false;

  public bool moveToDairy = false;

  public bool moveToDairy2 = false;

  public bool moveToFrozenFood = false;

  public bool moveToFrozenTreats = false;

  public bool moveToMeat = false;

  public bool moveToMeat2 = false;

  public bool moveToPaperProducts = false;

  public bool moveToPersonalCare = false;

  public bool moveToProduce = false;

  public bool moveToSnacks = false;

  public bool moveToWine = false;

  public bool movingToLocation = false;

  void Start()
  {
    player = GameObject.FindWithTag("Player");

    employee = GameObject.FindWithTag("Employee");

    askForHelpMenuCanvas = GameObject.FindWithTag("AskMenuCanvas");

    eventSystem = GameObject.FindWithTag("EventSystem");

    // beveragesButton = GameObject.FindWithTag("BeveragesButton");

    //Time.timeScale = 0;

    startPos = employee.transform.position;
  }

  void Update()
  {
    if (Input.GetButtonDown("Oculus_CrossPlatform_Button4"))
    {
      eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(beveragesButton);
    }
    if (moveToBeverages)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[5].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[5].transform.position.x,
      employee.transform.position.y, movePoints[5].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToBoxDinners)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
       movePoints[3].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[3].transform.position.x,
      employee.transform.position.y, movePoints[3].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToBread)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
       movePoints[0].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[0].transform.position.x,
      employee.transform.position.y, movePoints[0].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToCannedFood)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
       movePoints[5].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[5].transform.position.x,
      employee.transform.position.y, movePoints[5].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToCereal)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
       movePoints[1].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[1].transform.position.x,
      employee.transform.position.y, movePoints[1].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToDairy)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
       movePoints[5].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[5].transform.position.x,
      employee.transform.position.y, movePoints[5].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToFrozenFood)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[4].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[4].transform.position.x,
      employee.transform.position.y, movePoints[4].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToFrozenTreats)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[4].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[4].transform.position.x,
      employee.transform.position.y, movePoints[4].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToMeat)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[1].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[1].transform.position.x,
      employee.transform.position.y, movePoints[1].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    //    if (employee.transform.position == movePoint3.transform.position)
    //    {
    //        resetMoveToPoints();
    //        moveToMeat2 = true;
    //    }
    //}

    //if (moveToMeat2  )
    //{
    //        employee.transform.position = Vector3.MoveTowards(employee.transform.position,
    //        movePoint10.transform.position, Time.deltaTime * walkSpeed);
    //        Vector3 rotateTowardmovePoint2 = new Vector3(movePoint10.transform.position.x,
    //        employee.transform.position.y, movePoint10.transform.position.z);
    //        employee.transform.LookAt(rotateTowardmovePoint2);
    //        checkDistance();
    //}

    if (moveToPaperProducts)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[7].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[7].transform.position.x,
      employee.transform.position.y, movePoints[7].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToPersonalCare)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[6].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[6].transform.position.x,
      employee.transform.position.y, movePoints[6].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToProduce)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[8].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[8].transform.position.x,
      employee.transform.position.y, movePoints[8].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

    if (moveToSnacks)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position, movePoints[2].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[2].transform.position.x, employee.transform.position.y, movePoints[2].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }

  

    if (moveToWine)
    {
      employee.transform.position = Vector3.MoveTowards(employee.transform.position,
      movePoints[8].transform.position, Time.deltaTime * walkSpeed);
      Vector3 rotateTowardmovePoint = new Vector3(movePoints[8].transform.position.x,
      employee.transform.position.y, movePoints[8].transform.position.z);
      employee.transform.LookAt(rotateTowardmovePoint);
      checkDistance();
    }
  }

  public void resetMoveToPoints()
  {
    moveToBeverages = false;
    moveToBread = false;
    moveToBoxDinners = false;
    moveToCannedFood = false;
    moveToCereal = false;
    moveToDairy = false;
    moveToFrozenFood = false;
    moveToFrozenTreats = false;
    moveToPersonalCare = false;
    moveToProduce = false;
    moveToPaperProducts = false;
    moveToMeat = false;
    moveToSnacks = false;
    moveToWine = false;
    movingToLocation = false;
  }
  public void checkDistance()
  {
    askForHelpMenuCanvas.GetComponent<Canvas>().enabled = false;
    if (employee.transform.position == movePoints[0].transform.position || employee.transform.position == movePoints[1].transform.position || employee.transform.position == movePoints[2].transform.position || employee.transform.position == movePoints[3].transform.position || employee.transform.position == movePoints[4].transform.position || employee.transform.position == movePoints[5].transform.position || employee.transform.position == movePoints[6].transform.position || employee.transform.position == movePoints[7].transform.position || employee.transform.position == movePoints[8].transform.position)
    {
      resetMoveToPoints();
    }
  }

  public void MoveToSnacks()
  {
    resetMoveToPoints();
    moveToSnacks = true;

  }

  public void MoveToBeverages()
  {
    resetMoveToPoints();
    moveToBeverages = true;
  }

  public void MoveToBread()
  {
    resetMoveToPoints();
    moveToBread = true;
  }

  public void MoveToBoxDinners()
  {
    resetMoveToPoints();
    moveToBoxDinners = true;
  }

  public void MoveToCannedFood()
  {
    resetMoveToPoints();
    moveToCannedFood = true;
  }

  public void MoveToCereal()
  {
    resetMoveToPoints();
    moveToCereal = true;
  }

  public void MoveToDairy()
  {
    resetMoveToPoints();
    moveToDairy = true;
  }
  public void MoveToFrozenFood()
  {
    resetMoveToPoints();
    moveToFrozenFood = true;
  }

  public void MoveToFrozenTreats()
  {
    resetMoveToPoints();
    moveToFrozenTreats = true;
  }

  public void MoveToMeat()
  {
    resetMoveToPoints();
    moveToMeat = true;
  }

  public void MoveToPaperProducts()
  {
    resetMoveToPoints();
    moveToPaperProducts = true;
  }

  public void MoveToPersonalCare()
  {
    resetMoveToPoints();
    moveToPersonalCare = true;
  }

  public void MoveToProduce()
  {
    resetMoveToPoints();
    moveToProduce = true;
  }


  public void MoveToWine()
  {
    resetMoveToPoints();
    moveToWine = true;
  }

  public void closeAskMenu()
  {
    //Time.timeScale = 1;
    askForHelpMenuCanvas.GetComponent<Canvas>().enabled = false;
  }

}
