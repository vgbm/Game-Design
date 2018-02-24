using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {
	//https://forum.unity.com/threads/send-message-to-other-scene.41224/

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;
	[SerializeField] private TextMesh scoreLabel;
	
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	private int _score = 0;

	public bool canReveal {
		get {return _secondRevealed == null;}
	}

	// Use this for initialization
	void Start() {
		Vector3 startPos = originalCard.transform.position;

		// create shuffled list of cards
		int[] numbers = BuildCardIdArray();
		numbers = ShuffleArray(numbers);

		// place cards in a grid
		for (int i = 0; i < BoardInfo.numCols; i++) {
			for (int j = 0; j < BoardInfo.numRows; j++) {
				MemoryCard card;

				// use the original for the first grid space
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate(originalCard) as MemoryCard;
				}

				// next card in the list for each grid space
				int index = j * BoardInfo.numCols + i;
				int id = numbers[index];

				//TODO set images to proper value
				//card.SetCard(id, images[id]);
				card.SetCard(id, images[0]);

				float posX = (BoardInfo.offsetX * i) + startPos.x;
				float posY = -(BoardInfo.offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
				card.transform.localScale = new Vector3(BoardInfo.scaleX, BoardInfo.scaleY, 1f);
			}
		}
	}

	private int[] BuildCardIdArray() {
		int[] cards = new int[BoardInfo.numCols * BoardInfo.numRows];

		for (int i = 0; i < cards.Length; i++) {
			cards [i] = i / 2;
		}

		return cards;
	}

	// Knuth shuffle algorithm
	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone() as int[];
		for (int i = 0; i < newArray.Length; i++ ) {
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}
	
	private IEnumerator CheckMatch() {

		// increment score if the cards match
		if (_firstRevealed.id == _secondRevealed.id) {
			_score++;
			scoreLabel.text = "Score: " + _score;
		}

		// otherwise turn them back over after .5s pause
		else {
			yield return new WaitForSeconds(.5f);

			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}
		
		_firstRevealed = null;
		_secondRevealed = null;
	}

	public void Restart() {
		SceneManager.LoadScene("Menu");
	}
}
