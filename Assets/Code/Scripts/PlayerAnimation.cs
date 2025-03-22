using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem groundHitParticlesPrefab;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    private string currentState;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    
    void Update(){
        UpdateAnimation();
    }

    private void SetAnimation(string state){
        if (state.Equals(currentState)){
            return;
        }

        animator.Play(state);
    }

    private void UpdateAnimation(){
        if (!playerController._grounded){
            SetAnimation("MCJump");
        }
        else if (playerController.FrameInput.x == 0){
            SetAnimation("MCIdle");
        }
        else if (!playerController.isWallSliding){
            SetAnimation("MCRun");
        }
        else{
            SetAnimation("MCIdle");
        }

        if (playerController.facingRight){
            spriteRenderer.flipX = false;
        }
        else{
            spriteRenderer.flipX = true;
        }
    }

    private void PlayGroundHitParticles(){
        // Instantiate and play ground hit particle effect
        if (groundHitParticlesPrefab != null)
        {
            ParticleSystem newParticles = Instantiate(groundHitParticlesPrefab, transform.position, Quaternion.identity);
            newParticles.Play();
            Destroy(newParticles.gameObject, 1f); // Destroy after 1 second
        }
    }
}
