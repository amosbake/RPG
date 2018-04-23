using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    private const string LAYER_IDLE = "Idle Layer";
    private const string LAYER_WALK = "Walk Layer";
    private const string LAYER_Attack = "Attack Layer";

    [SerializeField] private float MoveSpeed = 1f;

    [SerializeField] protected Transform hitBox;

    public CharacterData _characterData { get; private set; }

    protected Animator animator;
    private Rigidbody2D rigidbody2D;
    protected Vector2 MoveDirection;
    protected Coroutine attackCorotine;

    public bool IsMoving
    {
        get { return MoveDirection.x != 0 || MoveDirection.y != 0; }
    }

    protected bool isAttacking;

    // Use this for initialization
    protected virtual void Start()
    {
        MoveDirection = Vector2.zero;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnDestroy()
    {
        if (_characterData != null)
        {
            _characterData.OnCharacterDie -= OnCharacterDie;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetupData(CharacterData characterData)
    {
        _characterData = characterData;
        _characterData.SetupData();
        _characterData.OnCharacterDie += OnCharacterDie;
    }

    public void Move()
    {
        rigidbody2D.velocity = MoveDirection * MoveSpeed;
        if (_characterData != null)
        {
            _characterData.currentPosition = transform.position;
        }
    }

    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActiveLayer(LAYER_WALK);
            animator.SetFloat("x", MoveDirection.x);
            animator.SetFloat("y", MoveDirection.y);
            StopAttack();
        }
        else if (isAttacking)
        {
            ActiveLayer(LAYER_Attack);
        }
        else
        {
            ActiveLayer(LAYER_IDLE);
        }
    }

    public virtual void StopAttack()
    {
        isAttacking = false;
        animator.SetBool("attack", false);
        if (attackCorotine != null)
        {
            StopCoroutine(attackCorotine);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (_characterData != null)
        {
            _characterData.TakeDamage(damage);
        }
    }


    public void ActiveLayer(string layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

    protected void OnCharacterDie()
    {
        animator.SetTrigger("die");
    }
}