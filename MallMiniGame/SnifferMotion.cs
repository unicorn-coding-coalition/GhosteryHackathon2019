using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnifferMotion : MonoBehaviour
{
  internal Transform thisTransform;
  SpriteRenderer m_SpriteRenderer;

  // The movement speed of the object
  public float moveSpeed = 0.5f;

  // A minimum and maximum time delay for taking a decision, choosing a direction to move in
  public Vector2 decisionTime = new Vector2(1, 4);
  internal float decisionTimeCount = 0;

  // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
  internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.zero, Vector3.up, Vector3.down };
  internal int currentMoveDirection;

  public bool debugOn;

  // Use this for initialization
  void Start()
  {
      // Cache the transform for quicker access
      thisTransform = this.transform;

      //Fetch the SpriteRenderer from the GameObject
      m_SpriteRenderer = GetComponent<SpriteRenderer>();

      // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
      decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

      // Choose a movement direction, or stay in place
      currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
  }

  void OnCollisionEnter2D(Collision2D col) {
      //Debug.Log(col.tag);
      if (debugOn) Debug.Log(this.gameObject.name + " collision with " + col.gameObject.tag);
      decisionTimeCount = 0;
  }

  // Update is called once per frame
  void Update()
  {
      // Move the object in the chosen direction at the set speed
      thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

      if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
      else
      {
          // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
          decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

          // Choose a movement direction, or stay in place
          ChooseMoveDirection();
      }
  }

  void ChooseMoveDirection()
  {
      // Choose whether to move sideways or up/down
      //currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
      currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
      m_SpriteRenderer.flipX = (currentMoveDirection == 0) ? true : false;
  }
}
