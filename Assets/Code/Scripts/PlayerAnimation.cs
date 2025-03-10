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
        if (playerController.FrameInput.x == 0){
            SetAnimation("MCIdle");
        }
        else if (playerController.FrameInput.x > 0 && !playerController.isWallSliding){
            SetAnimation("MCRun");
            spriteRenderer.flipX = false;
        }
        else if (playerController.FrameInput.x < 0 && !playerController.isWallSliding){
            SetAnimation("MCRun");
            spriteRenderer.flipX = true;
        }
        else{
            SetAnimation("MCIdle");
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
