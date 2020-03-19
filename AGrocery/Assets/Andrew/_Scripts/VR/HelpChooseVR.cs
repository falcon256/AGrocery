using System.Collections;
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

    public Transform movePoint1;
    public Transform movePoint2;
    public Transform movePoint3;
    public Transform movePoint4;
    public Transform movePoint5;
    public Transform movePoint6;
    public Transform movePoint7;
    public Transform movePoint8;
    public Transform movePoint9;
    public Transform movePoint10;
    public Transform movePoint11;
    public Transform movePoint12;

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

        beveragesButton = GameObject.FindWithTag("BeveragesButton");

        //Time.timeScale = 0;

        startPos = employee.transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown("Oculus_CrossPlatform_Button4"))
        {
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(beveragesButton);
        }
        if (moveToBeverages  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint7.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint7.transform.position.x,
            employee.transform.position.y, movePoint7.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

            if (moveToBoxDinners  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint4.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint4.transform.position.x,
            employee.transform.position.y, movePoint4.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToBread  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint1.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint1.transform.position.x,
            employee.transform.position.y, movePoint1.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToCannedFood  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint6.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint6.transform.position.x,
            employee.transform.position.y, movePoint6.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToCereal  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint2.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint2.transform.position.x,
            employee.transform.position.y, movePoint2.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToDairy  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint5.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint5.transform.position.x,
            employee.transform.position.y, movePoint5.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

            if (moveToFrozenFood  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint5.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint5.transform.position.x,
            employee.transform.position.y, movePoint5.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToFrozenTreats  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint5.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint5.transform.position.x,
            employee.transform.position.y, movePoint5.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToMeat  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint3.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint3.transform.position.x,
            employee.transform.position.y, movePoint3.transform.position.z);
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

            if (moveToPaperProducts  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint8.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint8.transform.position.x,
            employee.transform.position.y, movePoint8.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToPersonalCare  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint7.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint7.transform.position.x,
            employee.transform.position.y, movePoint7.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToProduce  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint9.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint9.transform.position.x,
            employee.transform.position.y, movePoint9.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToSnacks  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint3.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint3.transform.position.x,
            employee.transform.position.y, movePoint3.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }

        if (moveToWine  )
        {
            employee.transform.position = Vector3.MoveTowards(employee.transform.position,
            movePoint9.transform.position, Time.deltaTime * walkSpeed);
            Vector3 rotateTowardmovePoint = new Vector3(movePoint9.transform.position.x,
            employee.transform.position.y, movePoint9.transform.position.z);
            employee.transform.LookAt(rotateTowardmovePoint);
            checkDistance();
        }    
    }

    public void resetMoveToPoints()
    {
        moveToBeverages = false;
        moveToBeverages2 = false;
        moveToBread = false;
        moveToBoxDinners = false;
        moveToCannedFood = false;
        moveToCereal = false;
        moveToDairy = false;
        moveToDairy2 = false;
        moveToFrozenFood = false;
        moveToFrozenTreats = false;
        moveToPersonalCare = false;
        moveToProduce = false;
        moveToPaperProducts = false;
        moveToMeat = false;
        moveToMeat2 = false;
        moveToSnacks = false;
        moveToWine = false;
        movingToLocation = false;
    }
    public void checkDistance()
    {
        askForHelpMenuCanvas.GetComponent<Canvas>().enabled = false;
        if (employee.transform.position == movePoint1.transform.position || employee.transform.position == movePoint2.transform.position || employee.transform.position == movePoint3.transform.position || employee.transform.position == movePoint4.transform.position || employee.transform.position == movePoint5.transform.position || employee.transform.position == movePoint6.transform.position || employee.transform.position == movePoint7.transform.position || employee.transform.position == movePoint8.transform.position || employee.transform.position == movePoint9.transform.position)
        {
            resetMoveToPoints();            
        }            
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

    public void MoveToSnacks()
    {
        resetMoveToPoints();
        moveToSnacks = true;
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
